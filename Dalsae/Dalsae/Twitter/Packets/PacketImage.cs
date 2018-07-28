using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
    class PacketImage : BasePacket
	{
		public PacketImage(string url)
		{
			this.url = url;
			method = "GET";
		}
	}
}