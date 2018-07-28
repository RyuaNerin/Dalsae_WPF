using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    class PacketHomeTimeLine : BasePacket
    {
        public PacketHomeTimeLine()
        {
            url = "https://api.twitter.com/1.1/statuses/home_timeline.json";
            method = "GET";
            eresponse = eResponse.TIME_LINE;
            count = 40.ToString();
            tweet_mode = "extended";
        }
        public object count { get { return dicParams["count"]; } set { dicParams["count"] = value.ToString(); } }
        public string tweet_mode { get { return dicParams["tweet_mode"]; } set { dicParams["tweet_mode"] = value; } }
        public object max_id { get { return dicParams["max_id"]; } set { dicParams["max_id"] = value.ToString(); isMore = true; } }
        //public string MaxId { set { dicParams["max_id"] = value; } }
        //public string TrimUser { set { dicParams["trim_user"] = value; } }
        //public string ExcludeReplies { set { dicParams["exclude_replies"] = value; } }
    }
}