using System;
using System.Globalization;

namespace Dalsae.Twitter.Extended
{
    //dm용 클래스, 보내는 사람 정보
    public class ClientSender
	{
		private DateTime dateTime;
		public object created_at { get { return dateTime; } set { SetDateTime(value); } }
		//public long id { get; set; }
		public string name { get; set; }
		public string screen_name { get; set; }
		public string profile_image_url { get; set; }
		private void SetDateTime(object value)
		{
			dateTime = DateTime.ParseExact(value.ToString(), "ddd MMM dd HH:mm:ss zzzz yyyy", CultureInfo.InvariantCulture);
		}
	}
}
