using System;
using System.Globalization;
using System.Web;
using Dalsae.Template;

namespace Dalsae.Twitter.Extended
{
    //dm용 클래스
    public class ClientDirectMessage
	{
		public UIProperty uiProperty { get; set; } = new UIProperty();
		private string _text;
		private DateTime _dateTime;
		public DateTime dateTime { get { return _dateTime; } }

		public void Init()//링크 변환 등
		{
			if (entities == null) return;

			if (entities.urls != null)
			{
				for (int i = 0; i < entities.urls.Count; i++)
					_text = _text.Replace(entities.urls[i].url, entities.urls[i].display_url);
			}

			if(entities.media!=null)
			{
				//for(int i=0;i<entities.media.Count;i++)
				if (entities.media.Count > 0)
					_text = _text.Replace(entities.media[0].url, entities.media[0].display_url);
			}
		}
		public string nameText { get { return string.Format("From {0} / {1} To {2} / {3}", sender.screen_name, sender.name,
									recipient.screen_name, recipient.name); } }
		public string dateString { get { return _dateTime.ToString("yyyy년 MMM월 dd일 dddd HH:mm:ss"); } }
		public object created_at { get { return _dateTime; } set { SetDateTime(value); } }
        public ClientEntities entities { get; set; }
		public ClientSender sender { get; set; }
		public ClientRecipient recipient { get; set; }
		public long id { get; set; }
        public long recipient_id { get; set; }
        public string recipient_screen_name { get; set; }
        public long sender_id { get; set; }
        public string sender_screen_name { get; set; }
		public string text { get { return _text; } set { _text = HttpUtility.HtmlDecode(value); } }
		private void SetDateTime(object value)
		{
			_dateTime = DateTime.ParseExact(value.ToString(), "ddd MMM dd HH:mm:ss zzzz yyyy", CultureInfo.InvariantCulture);
		}
	}
}
