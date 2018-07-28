using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    class PacketTweetDelete : BasePacket
	{
		public PacketTweetDelete(long id)
		{
			url = "https://api.twitter.com/1.1/statuses/destroy/" + id + ".json";
			method = "POST";
			this.id = id.ToString();
			eresponse = eResponse.DELETE_TWEET;
		}
		public object id { get { return dicParams["id"]; } set { dicParams["id"] = value.ToString(); } }
		public string trim_user { get { return dicParams["trim_user"]; } set { dicParams["trim_user"] = value.ToString(); } }
	}
}