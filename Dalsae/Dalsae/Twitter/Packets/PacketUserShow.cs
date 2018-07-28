using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    public class PacketUserShow : BasePacket
	{
		public PacketUserShow(string screen_name)
		{
			url = "https://api.twitter.com/1.1/users/show.json";
			method = "GET";
			eresponse = eResponse.USER_INFO;
			this.screen_name = screen_name;
		}
		public string screen_name { get { return dicParams["screen_name"]; } set { dicParams["screen_name"] = value.ToString(); } }
	}
}