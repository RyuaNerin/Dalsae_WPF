using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    //유저 트윗 긁을 떄 사용
    class PacketUserTimeLine : BasePacket
	{
		public PacketUserTimeLine()
		{
			url = "https://api.twitter.com/1.1/statuses/user_timeline.json";
			method = "GET";
			eresponse = eResponse.USER_TIMELINE;
			count = 40.ToString();
			tweet_mode = "extended";
			//exclude_replies = true;
			//trim_user = true;
		}
		//public object user_id { get { return dicParams["user_id"]; } set { dicParams["user_id"] = value.ToString(); } }
		public string screen_name { get { return dicParams["screen_name"]; } set { dicParams["screen_name"] = value; } }
		public object max_id { get { return dicParams["max_id"]; } set { dicParams["max_id"] = value.ToString(); isMore = true; } }
		public string count { get { return dicParams["count"]; } set { dicParams["count"] = value; } }
		public string tweet_mode { get { return dicParams["tweet_mode"]; } set { dicParams["tweet_mode"] = value; } }
		//public object trim_user { get { return dicParams["trim_user"]; } set { dicParams["trim_user"] = value.ToString(); } }
		//public object exclude_replies { get { return dicParams["exclude_replies"]; } set { dicParams["exclude_replies"] = value.ToString(); } }
		//public object contributor_details { get { return dicParams["contributor_details"]; } set { dicParams["contributor_details"] = value.ToString(); } }
		//public object include_rts { get { return dicParams["include_rts"]; } set { dicParams["include_rts"] = value.ToString(); } }
	}
}