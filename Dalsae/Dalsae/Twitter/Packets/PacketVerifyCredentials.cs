using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    //자기 정보 긁을 때 사용
    class PacketVerifyCredentials : BasePacket
	{
		public PacketVerifyCredentials()
		{
			url = "https://api.twitter.com/1.1/account/verify_credentials.json";
			method = "GET";
			eresponse = eResponse.MY_INFO;
		}
	}
}