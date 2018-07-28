using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    public class PacketSingleTweet : BasePacket
	{
		public PacketSingleTweet(string id)
		{
			url = "https://api.twitter.com/1.1/statuses/show.json";
			method = "GET";
			eresponse = eResponse.SINGLE_TWEET;
			this.id = id;
			tweet_mode = "extended";
		}
		public object id { get { return dicParams["id"]; } set { dicParams["id"] = value.ToString(); } }
		public string tweet_mode { get { return dicParams["tweet_mode"]; } set { dicParams["tweet_mode"] = value; } }
	}
}