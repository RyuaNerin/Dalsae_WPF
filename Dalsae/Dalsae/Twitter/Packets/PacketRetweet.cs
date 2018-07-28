using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    //retweet
    class PacketRetweet : BasePacket
	{
		public PacketRetweet(long id)
		{
			url = "https://api.twitter.com/1.1/statuses/retweet/" + id + ".json";
			method = "POST";
			eresponse = eResponse.RETWEET;
			this.id = id;
		}
		public object id { get { return dicParams["id"]; } set { dicParams["id"] = value.ToString(); } }
	}
}