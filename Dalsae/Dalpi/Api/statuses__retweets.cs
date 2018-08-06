using Dalpi.Objects;

namespace Dalpi.Api
{
    public static partial class statuses
    {
        /// <summary>
        /// https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/get-statuses-retweets-id
        /// </summary>
        public class retweets : BaseApi<Status[]>
        {
            public retweets()
                : base("GET", "https://api.twitter.com/1.1/statuses/retweets/{id}.json")
            { }

            [IsArgument]
            public long id { get; set; }

            [IsArgument]
            public int? count { get; set; }

            [IsArgument]
            public bool? trim_user { get; set; }
        }
    }
}