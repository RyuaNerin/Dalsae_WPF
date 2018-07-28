using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    //Pin받기위해 띄움
    class PacketGetOAuth : BasePacket
	{
		public PacketGetOAuth()
		{
			this.url = "https://api.twitter.com/oauth/request_token";
			this.method = "POST";
			oauth_callback = "oob";
		}
		public string oauth_callback { get { return dicParams["oauth_callback"]; } set { dicParams["oauth_callback"] = value; } }
	}
}