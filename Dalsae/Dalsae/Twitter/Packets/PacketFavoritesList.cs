using Dalsae.API;

using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    class PacketFavoritesList : BasePacket
	{
		public PacketFavoritesList()
		{
			url = "https://api.twitter.com/1.1/favorites/list.json";
			method = "GET";
			eresponse = eResponse.FAVORITE_LIST;
			count = 40.ToString();
			tweet_mode = "extended";
		}
		public object user_id { get { return dicParams["user_id"]; } set { dicParams["user_id"] = value.ToString(); } }
		public string screen_name { get { return dicParams["screen_name"]; } set { dicParams["screen_name"] = value; } }
		public string count { get { return dicParams["count"]; } set { dicParams["count"] = value; } }
		public object max_id { get { return dicParams["max_id"]; } set { dicParams["max_id"] = value.ToString(); isMore = true; } }
		public string tweet_mode { get { return dicParams["tweet_mode"]; } set { dicParams["tweet_mode"] = value; } }
	}
}