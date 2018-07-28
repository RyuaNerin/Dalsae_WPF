using System.Net;
using Dalsae.Twitter.Packets;

namespace Dalsae.Twitter.Objects
{
    class TwitterRequest
	{
		public TwitterRequest(HttpWebRequest req, BasePacket parameter)
		{
			this.parameter = parameter;
			this.request = req;
		}
		public BasePacket parameter { get; private set; }
		public HttpWebRequest request { get; private set; }
	}
}
