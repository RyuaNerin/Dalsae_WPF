using System.Collections.Generic;
using Dalsae.Twitter.Objects;
using Dalsae.Manager;

namespace Dalsae.Template
{
    public class UIProperty:BaseNoty
	{
		public TweetList childNode { get; private set; } = new TweetList();
		public UIProperty parentTweet { get; set; }
		public delegate void DeleAddSingleTweet(ClientTweet tweet, UIProperty parent, bool isQT);
		private HashSet<long> hashTweet = new HashSet<long>();//대화 트윗 hash
		private bool _isDeleteTweet = false;
		public bool isDeleteTweet
		{
			get { return _isDeleteTweet; }
			set { _isDeleteTweet = value; OnPropertyChanged("isDeleteTweet"); }
		}
		private bool _isHighlight = false;
		public bool isHighlight
		{
			get { return _isHighlight; }
			set { _isHighlight = value; OnPropertyChanged("isHighlight"); }
		}
		private bool _isShowQtTweet = false;

		private bool _isBackOne = true;
		public bool isBackOne
		{
			get { return _isBackOne; }
			set { _isBackOne = value; OnPropertyChanged("isBackOne"); }
		}

		public bool isQtTweet { get; private set; } = false;
		/// <summary>
		/// Delegate용 함수, 인용&대화 트윗을 불러와서 추가 할 때 사용
		/// </summary>
		/// <param name="tweet">인용&대화 트윗</param>
		/// <param name="parent">부모 트윗, 인용일 경우 인용이 오고 아닐 경우 상위 트윗이 옴</param>
		/// <param name="isDeahwa">대화인지 인용인지, true: 대화 / false: 인용</param>
		public void AddSingleTweet(ClientTweet tweet, UIProperty parent, bool isQT)
		{
			//부모 연결, 인용 트윗 설정
			tweet.uiProperty.parentTweet = parent == null ? this : parent;
			tweet.uiProperty.isQtTweet = isQT;
			
			if(parent==null)//TL에 보이는 최상위 트윗에서 호출
				AddTweet(tweet);
			else//하위 트윗에서 호출, 인용 혹은 대화에서 호출 시
				parent.AddTweet(tweet);
		}

		/// <summary>
		/// 하위 트윗 추가(대화, 인용)
		/// </summary>
		/// <param name="tweet">대화 트윗</param>
		private void AddTweet(ClientTweet tweet)
		{
			if (hashTweet.Contains(tweet.id)) return;

			hashTweet.Add(tweet.id);
			childNode.Add(tweet);
		}

		/// <summary>
		/// 트리뷰에서 닫을 경우 하위 트윗을 날린다. 캐싱은 나중에 생각 하자
		/// </summary>
		/// <param name="tweet"></param>
		public void ClearDeahwa()
		{
			childNode.Clear();
			hashTweet.Clear();
		}
	}
}
