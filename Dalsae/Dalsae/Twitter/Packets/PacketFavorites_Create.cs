using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    //관글 on
    class PacketFavorites_Create : BasePacket
    {
        public PacketFavorites_Create()
        {
            url = "https://api.twitter.com/1.1/favorites/create.json";
            method = "POST";
            eresponse = eResponse.FAVORITE_CREATE;
        }

        public object id { get { return dicParams["id"]; } set { dicParams["id"] = value.ToString(); } }
        public string include_entities { get { return dicParams["include_entities"]; } set { dicParams["include_entities"] = value.ToString(); } }
    }
}