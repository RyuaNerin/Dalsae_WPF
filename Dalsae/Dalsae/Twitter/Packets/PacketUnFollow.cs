using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    class PacketUnFollow : BasePacket
	{
		public PacketUnFollow(string screen_name)
		{
			url = "https://api.twitter.com/1.1/friendships/destroy.json";
			method = "POST";
			eresponse = eResponse.UNFOLLOWING;
			this.screen_name = screen_name;
		}
		public string screen_name { get { return dicParams["screen_name"]; } set { dicParams["screen_name"] = value.ToString(); } }
		public object user_id { get { return dicParams["user_id"]; } set { dicParams["user_id"] = value.ToString(); } }
	}
}