using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    class PacketFollowingIds : BasePacket//팔로잉 아이디만 가져옴, max 5000
	{
		public PacketFollowingIds()
		{
			url = "https://api.twitter.com/1.1/friends/ids.json";
			method = "GET";
			eresponse = eResponse.FOLLOWING_IDS;
		}
	}
}