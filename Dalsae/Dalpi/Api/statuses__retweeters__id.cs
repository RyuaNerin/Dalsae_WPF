namespace Dalpi.Params
{
    public static partial class Statuses
    {
        public static partial class Retweets
        {
            /// <summary>
            /// https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/get-statuses-retweeters-ids
            /// </summary>
            public class Id : BaseParam<IdCollection>
            {
                public Id()
                    : base("GET", "https://api.twitter.com/1.1/statuses/retweets/{0}.json")
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