namespace Dalpi.Api
{
    public static partial class statuses
    {
        /// <summary>
        /// https://developer.twitter.com/en/docs/tweets/post-and-engage/api-reference/get-statuses-lookup
        /// </summary>
        public class lookup : BaseParam<(string token, string secret)>
        {
            public lookup()
                : base("GET", "https://api.twitter.com/1.1/statuses/lookup.json")
            { }


            [IsArgument]
            public long id { get; set; }

            [IsArgument]
            public bool? include_entities { get; set; }

            [IsArgument]
            public bool? trim_user { get; set; }

            [IsArgument]
            public bool? map { get; set; }

            [IsArgument]
            public bool? include_ext_alt_text { get; set; }

            [IsArgument]
            public bool? include_card_uri { get; set; }
        }
    }
}