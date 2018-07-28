using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    //다중계정 아이디 변경 확인 용
    class PacketLookUp : BasePacket
	{
		public PacketLookUp(long user_id)
		{
			this.url = "https://api.twitter.com/1.1/users/lookup.json";
			this.method = "GET";
		}
		public object user_id { get { return dicParams["user_id"]; } set { dicParams["user_id"] = value.ToString(); } }
	}
}