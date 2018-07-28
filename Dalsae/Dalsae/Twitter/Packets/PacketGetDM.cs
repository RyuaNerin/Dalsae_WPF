
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Dalsae.API;

namespace Dalsae.Twitter.Packets
{
	public class PacketGetDM : BasePacket
	{
		public PacketGetDM()
		{
			url = "https://api.twitter.com/1.1/direct_messages.json";
			method = "GET";
			eresponse = eResponse.GET_DM;
			count = 20;
		}
		public object count { get { return dicParams["count"]; } set { dicParams["count"] = value.ToString(); } }
	}
}