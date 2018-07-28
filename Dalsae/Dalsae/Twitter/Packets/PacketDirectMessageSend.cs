using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    public class PacketDirectMessageSend : BasePacket
	{
		public PacketDirectMessageSend()
		{
			url = "https://api.twitter.com/1.1/direct_messages/new.json";
			method = "GET";
			eresponse = eResponse.SEND_DM;
		}
		public object screen_name { get { return dicParams["screen_name"]; } set { dicParams["screen_name"] = value.ToString(); } }
		public object user_id { get { return dicParams["user_id"]; } set { dicParams["user_id"] = value.ToString(); } }
	}
}