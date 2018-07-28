using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    class PacketBlockIds : BasePacket//블락리스트, max 5000
	{
		public PacketBlockIds()
		{
			url = "https://api.twitter.com/1.1/blocks/ids.json";
			method = "GET";
			eresponse = eResponse.BLOCK_IDS;

		}
		public string stringify_ids { get { return dicParams["stringify_ids"]; } set { dicParams["stringify_ids"] = value.ToString(); } }
		public object cursor { get { return dicParams["cursor"]; } set { dicParams["cursor"] = value.ToString(); } }
	}
}