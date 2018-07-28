using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    class PacketBlockCreate : BasePacket
	{
		public PacketBlockCreate(long id)
		{
			url = "https://api.twitter.com/1.1/blocks/create.json";
			method = "POST";
			eresponse = eResponse.BLOCK_CREAE;
			this.user_id = id;
		}
		public object user_id { get { return dicParams["user_id"]; } set { dicParams["user_id"] = value.ToString(); } }
	}
}