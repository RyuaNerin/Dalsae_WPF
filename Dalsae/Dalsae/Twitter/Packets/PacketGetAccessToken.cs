using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    //핀 받고 엑세스 토큰받을 때 사용
    class PacketGetAccessToken : BasePacket
	{
		public PacketGetAccessToken()
		{
			this.url = "https://api.twitter.com/oauth/access_token";
			this.method = "POST";
		}
		public string oauth_verifier { get { return dicParams["oauth_verifier"]; } set { dicParams["oauth_verifier"] = value; } }
	}
}