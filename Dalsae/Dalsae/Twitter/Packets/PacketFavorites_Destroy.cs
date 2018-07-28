using Dalsae.API;

using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    //관글off
    class PacketFavorites_Destroy : BasePacket
	{
		public PacketFavorites_Destroy()
		{
			url = "https://api.twitter.com/1.1/favorites/destroy.json";
			method = "POST";
			eresponse = eResponse.FAVORITE_DESTROY;
		}

		public object id { get { return dicParams["id"]; } set { dicParams["id"] = value.ToString(); } }
		public string include_entities { get { return dicParams["include_entities"]; } set { dicParams["include_entities"] = value.ToString(); } }
	}
}