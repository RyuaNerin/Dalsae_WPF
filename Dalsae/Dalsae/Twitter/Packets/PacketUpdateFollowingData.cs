using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    public class PacketUpdateFollowingData : BasePacket
	{
		public PacketUpdateFollowingData()
		{
			url = "https://api.twitter.com/1.1/friendships/update.json";
			method = "POST";
			eresponse = eResponse.FOLLOWING_UPDATE;
		}

		public object user_id { get { return dicParams["user_id"]; } set { dicParams["user_id"] = value.ToString(); } }
		public object retweets { get { return dicParams["retweets"]; } set { dicParams["retweets"] = value.ToString(); } }
	}
}