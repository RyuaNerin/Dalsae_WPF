using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    class PacketFollowingList : BasePacket//팔로잉 리스트, max 200
	{
		public PacketFollowingList()
		{
			url = "https://api.twitter.com/1.1/friends/list.json";
			method = "GET";
			eresponse = eResponse.FOLLOWING_LIST;
			count = 40.ToString();
		}
		public object user_id { get { return dicParams["user_id"]; } set { dicParams["user_id"] = value.ToString(); } }
		public string screen_name { get { return dicParams["screen_name"]; } set { dicParams["screen_name"] = value.ToString(); } }
		public object cursor { get { return dicParams["cursor"]; } set { dicParams["cursor"] = value.ToString(); } }
		public object count { get { return dicParams["count"]; } set { dicParams["count"] = value.ToString(); } }
		public string skip_status { get { return dicParams["skip_status"]; } set { dicParams["skip_status"] = value.ToString(); } }
		public string include_user_entities { get { return dicParams["include_user_entities"]; } set { dicParams["include_user_entities"] = value.ToString(); } }
	}
}