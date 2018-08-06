namespace Dalpi.Api
{
    public static partial class statuses
    {
        /// <summary>
        /// https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/get-statuses-oembed
        /// </summary>
        public class oembed : BaseApi<object>
        {
            public oembed()
                : base("GET", "https://publish.twitter.com/oembed")
            {
                throw new System.NotImplementedException();
            }
        }
    }
}