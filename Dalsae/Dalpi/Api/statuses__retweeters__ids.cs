using Dalpi.Objects;

namespace Dalpi.Api
{
    public static partial class statuses
    {
        public static partial class retweeters
        {
            /// <summary>
            /// https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/get-statuses-retweeters-ids
            /// </summary>
            public class ids : BaseApi<IdCollection>
            {
                public ids()
                    : base("GET", "https://api.twitter.com/1.1/statuses/retweeters/ids.json")
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
}