using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    public class PacketFollow : BasePacket
	{
		public PacketFollow(string screen_name)
		{
			url = "https://api.twitter.com/1.1/friendships/create.json";
			method = "POST";
			eresponse = eResponse.FOLLOWING;
			this.screen_name = screen_name;
		}
		public string screen_name { get { return dicParams["screen_name"]; } set { dicParams["screen_name"] = value.ToString(); } }
		public object user_id { get { return dicParams["user_id"]; } set { dicParams["user_id"] = value.ToString(); } }
	}
}