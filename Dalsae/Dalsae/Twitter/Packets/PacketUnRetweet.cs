using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    //리트윗 취소
    class PacketUnRetweet : BasePacket
	{
		public PacketUnRetweet(long id)
		{
			url = "https://api.twitter.com/1.1/statuses/unretweet/" + id + ".json";
			method = "POST";
			eresponse = eResponse.UN_RETWEET;
			this.id = id;
		}

		public object id { get { return dicParams["id"]; } set { dicParams["id"] = value.ToString(); } }
	}
}