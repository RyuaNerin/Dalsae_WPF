using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    //트윗 업로드에 사용
    public class PacketUpdate : BasePacket
	{
		/// <summary>
		/// 트윗&DM 생성자
		/// </summary>
		/// <param name="isTweet">DM일 경우 false</param>
		public PacketUpdate(bool isTweet)
		{
			this.method = "POST";
			if (isTweet)
			{
				url = "https://api.twitter.com/1.1/statuses/update.json";
				eresponse = eResponse.UPDATE;
			}
			else
			{
				url = "https://api.twitter.com/1.1/direct_messages/new.json";
				eresponse = eResponse.SEND_DM;
			}
		}

		//-----------------DM용-------------------------
		public string text { get { return dicParams["text"]; } set { dicParams["text"] = value.ToString(); } }
		public object screen_name { get { return dicParams["screen_name"]; } set { dicParams["screen_name"] = value.ToString(); } }
		public object user_id { get { return dicParams["user_id"]; } set { dicParams["user_id"] = value.ToString(); } }
		//-------------------------------------------------
		public string status { get { return dicParams["status"]; } set { dicParams["status"] = value.ToString(); } }
		public string in_reply_to_status_id { get { return dicParams["in_reply_to_status_id"]; } set { dicParams["in_reply_to_status_id"] = value.ToString(); } }
		public string media_ids { get { return dicParams["media_ids"]; } set { dicParams["media_ids"] = value.ToString(); } }
		public string possibly_sensitive { set { dicParams["status"] = value.ToString(); } }
		public string lat { set { dicParams["status"] = value.ToString(); } }
		public string Long { set { dicParams["status"] = value.ToString(); } }
		public string place_id { set { dicParams["status"] = value.ToString(); } }
		public string display_coordinates { set { dicParams["status"] = value.ToString(); } }
		public string trim_user { set { dicParams["status"] = value.ToString(); } }
		//public string media_ids { set { dicParams["status"] = value.ToString(); } }
	}
}