using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using Dalsae.Template;
using static Dalsae.DataManager;

namespace Dalsae.Twitter.Objects
{
    public class ClientTweet : BaseNoty
	{
		//--------------------------------------------------------------------------------
		//-------------------------외부 참조용 변수-------------------------------------
		//--------------------------------------------------------------------------------
		[Newtonsoft.Json.JsonIgnore]
		public UIProperty uiProperty { get; set; } = new UIProperty();
		[Newtonsoft.Json.JsonIgnore]
		public ClientTweet originalTweet { get; private set; }
		
		public ClientTweet quoted_status { get; set; }//QT일 경우 해당 트윗 정보
		/// <summary>
		/// UI용 리트윗 여부 플래그
		/// </summary>
		public bool isRetweet { get; set; } = false;
		public bool isMedia { get; private set; } = false;//미디어가 있는지 여부
		public bool isPhoto { get; private set; } = false;//사진인지 여부
		public bool isMovie { get; private set; } = false;//동영상인지 여부
		public bool isReply { get; private set; } = false;
		public bool isQTRetweet { get; private set; } = false;
		public bool isUrl { get; private set; } = false;
		public bool isMention { get; private set; } = false;
		public ClientEntities mediaEntities { get; private set; }//미디어 엔티티
		public ClientEntities lastEntities { get; private set; }
		private string _dateString;
		public string dateString
		{
			get
			{
				if (string.IsNullOrEmpty(_dateString) || string.IsNullOrEmpty(source))
					return string.Empty;
				else if (_dateString == null || source == null)
					return "";
				else
					return $"{_dateString} / via {source}";
			}
			private set { _dateString = value; }
		}
		public string retweetText
		{
			get
			{
				if (user == null) return "";
				return $"Retweet By {user.screen_name} / {user.name}" ?? "";
			}
		}
		public string nameText
		{
			get
			{
				if (user == null) return "";
				return $"{user.screen_name} / {user.name}";
			}
		}

		public Dictionary<string, ClientMedia> dicPhoto { get; private set; } = new Dictionary<string, ClientMedia>();//key: displayUrl
		public ClientMedia tweetMovie { get; private set; } = null;
		public List<ClientURL> listUrl { get; private set; } = new List<ClientURL>();
		public HashSet<string> hashMention { get; private set; } = new HashSet<string>();

		public string full_text { get { return _text; } set { _text = HttpUtility.HtmlDecode(value); } }//API땡기면 full_text가 옴
		public string text { get { return _text; } set { _text = HttpUtility.HtmlDecode(value); } }//스트리밍이면 text로 와서 이렇게 사용
		public User user { get; set; }//트윗 쓴 사람 정보, 리트윗일 경우 리트윗 정보에 원 트윗 user정보 있음
		public ClientTweet retweeted_status { get; set; }
		public ClientEntities entities { get; set; }
		public ClientEntities extended_entities { get; set; }//이미지가 여러장일 경우 사용됨
		public string in_reply_to_status_id_str { get; set; }
		public string quoted_status_id_str { get; set; }//인용 리트윗 트윗 id
		public object created_at { get { return _dateTime; } set { SetDateTime(value); } }
		public long id { get; set; }//트윗 id
		public bool truncated { get; set; }//140자 넘는 경우 알려주는 거
		public ClientExtendedTweet extended_tweet { get; set; }
		public string source { get { return _source; } set { SetSource(value); } }
		public int retweet_count { get; set; }//리트윗 카운트
		public int favorite_count { get; set; }//별 카운트
		private bool _favorited;
		public bool favorited//별박았는지
		{
			get { return _favorited; }
			set { _favorited = value; OnPropertyChanged("favorited"); }
		}
		private bool _retweeted = false;
		public bool retweeted//리트윗 했는지
		{
			get { return _retweeted; }
			set { _retweeted = value; OnPropertyChanged("retweeted"); }
		}

		private bool isExtendTweet = false;
		public DateTime dateTime { get { return _dateTime; } }
		private DateTime _dateTime;
		private string _source;
		private string _text;//트윗이요
		public void Init()//t.co 문자 변환 등 변경이 필요한 값들을 변경해준다
		{
			if (originalTweet != null) return;
			SetOriginalTweet();
			SetBoolean();
			ReplaceText();

			//인용트윗일 경우 인용 트윗 내부 데이터도 init, API로 땡길 경우 차단 하거나 당한 경우에 인용 트윗 안 날아옴
			if (isQTRetweet && quoted_status != null)
				quoted_status.Init();
		}

		public ClientTweet() { }
		public ClientTweet(string stringTweet)
		{
			this.user = new User();
			this.originalTweet = this;
			originalTweet.text = stringTweet;
		}

		private void SetOriginalTweet()
		{
			if (retweeted_status != null)
			{
				//retweeted_status.retweeted = true;
				isRetweet = true;
			}
			if (isRetweet)
			{
				if (retweeted_status == null)
					originalTweet = this;
				else
					originalTweet = retweeted_status;
			}
			else
				originalTweet = this;
		}

		private void SetBoolean()
		{
			if (string.IsNullOrEmpty(originalTweet.in_reply_to_status_id_str) == false)
				isReply = true;
			if (string.IsNullOrEmpty(originalTweet.quoted_status_id_str) == false)
				isQTRetweet = true;
			if (originalTweet.extended_tweet != null)
				isExtendTweet = true;

			if (isExtendTweet)//확장 트윗일 경우 확장 트윗의 일반,확장 엔티티 설정
			{
				if (originalTweet.extended_tweet.extended_entities != null)
					mediaEntities = originalTweet.extended_tweet.extended_entities;
				else
					mediaEntities = originalTweet.entities;
				lastEntities = originalTweet.extended_tweet.entities;
			}
			else
			{
				if (originalTweet.extended_entities != null)
					mediaEntities = originalTweet.extended_entities;
				else
					mediaEntities = originalTweet.entities;
				lastEntities = originalTweet.entities;
			}
			if (mediaEntities?.media != null)
				if (mediaEntities.media.Count > 0)
					isMedia = true;

			for (int i = 0; i < lastEntities.user_mentions.Count; i++)
			{
				if (DataInstence.CheckIsMe(lastEntities.user_mentions[i].id))
					isMention = true;

				hashMention.Add(lastEntities.user_mentions[i].screen_name);
			}

			if (lastEntities.urls != null)
				if (lastEntities.urls.Count > 0)
					isUrl = true;
		}


		private void ReplaceText()
		{
			if (originalTweet.truncated)//140자가 넘는 트윗이나 이미지 2장이상??일 경우 사용
			{
				if (isExtendTweet)//140자가 넘을 경우 
					originalTweet._text = HttpUtility.HtmlDecode(originalTweet.extended_tweet.full_text);//140자 넘는 텍스트로 변경
				ReplaceURL(originalTweet);
			}
			else
				ReplaceURL(originalTweet);
		}

		private void ReplaceURL(ClientTweet tweet)
		{
			if (entities == null) return;

			if (isUrl)//url이 있을 경우 변경
				for (int i = 0; i < lastEntities.urls.Count; i++)
				{
					tweet._text = tweet._text.Replace(lastEntities.urls[i].url, lastEntities.urls[i].display_url);
					listUrl.Add(lastEntities.urls[i]);
				}

			if (isMedia)//미디어가 있을 경우
				for (int i = 0; i < mediaEntities.media.Count; i++)
				{
					tweet._text = tweet._text.Replace(mediaEntities.media[i].url, mediaEntities.media[i].display_url);
					if (dicPhoto.ContainsKey(mediaEntities.media[i].display_url) == false)
					{
						if(mediaEntities.media[i].type=="photo")
						{
							dicPhoto.Add(mediaEntities.media[i].display_url, mediaEntities.media[i]);
							isPhoto = true;
						}
						else
						{
							tweetMovie = mediaEntities.media[i];
							isMovie = true;
						}
					}
				}
		}

		private void SetDateTime(object value)
		{
			_dateTime = DateTime.ParseExact(value.ToString(), "ddd MMM dd HH:mm:ss zzzz yyyy", CultureInfo.InvariantCulture);
			dateString = _dateTime.ToString("F",CultureInfo.CurrentCulture);
		}

		private void SetSource(string value)
		{
			_source = System.Text.RegularExpressions.Regex.Replace(value, "<[^>]*>", string.Empty);
		}
	}
}
