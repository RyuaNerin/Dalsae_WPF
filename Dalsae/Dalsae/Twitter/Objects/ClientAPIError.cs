using System.Collections.Generic;

namespace Dalsae.Twitter.Objects
{
    public class ClientAPIError
	{
		public List<ClientError> errors { get; set; }
	}

	public class ClientError
	{
		public int code { get; set; }
	}
}
