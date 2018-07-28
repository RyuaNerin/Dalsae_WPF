using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    public class PacketBlockDestroy : BasePacket
	{
		public PacketBlockDestroy(long id)
		{
			url = "https://api.twitter.com/1.1/blocks/destroy.json";
			method = "POST";
			eresponse = eResponse.BLOCK_DESTROY;
			this.user_id = id;
		}
		public object user_id { get { return dicParams["user_id"]; } set { dicParams["user_id"] = value.ToString(); } }
	}
}