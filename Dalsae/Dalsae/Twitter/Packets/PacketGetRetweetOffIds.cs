using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    public class PacketGetRetweetOffIds : BasePacket
	{
		public PacketGetRetweetOffIds()
		{
			url = "https://api.twitter.com/1.1/friendships/no_retweets/ids.json";
			method = "GET";
			eresponse = eResponse.RETWEET_OFF_IDS;
		}
	}
}