using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    class PacketMentionTimeLine : BasePacket
	{
		public PacketMentionTimeLine()
		{
			url = "https://api.twitter.com/1.1/statuses/mentions_timeline.json";
			method = "GET";
			eresponse = eResponse.MENTION;
			count = 40.ToString();
			tweet_mode = "extended";
		}

		public string count { get { return dicParams["count"]; } set { dicParams["count"] = value.ToString(); } }
		public object max_id { get { return dicParams["max_id"]; } set { dicParams["max_id"] = value.ToString(); isMore = true; } }
		public string tweet_mode { get { return dicParams["tweet_mode"]; } set { dicParams["tweet_mode"] = value; } }
		//public string max_id { get { return dicParams["max_id"]; } set { dicParams["max_id"] = value.ToString(); } }
		//public string trim_user { get { return dicParams["trim_user"]; } set { dicParams["trim_user"] = value.ToString(); } }
		//public string include_entities { get { return dicParams["include_entities"]; } set { dicParams["include_entities"] = value.ToString(); } }
	}
}