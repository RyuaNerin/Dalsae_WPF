namespace Dalpi.Api
{
    public static class oauth
    {
        public class request_token : BaseParam<(string token, string secret)>
        {
            public request_token()
                : base("POST", "https://api.twitter.com/oauth/request_token")
            { }

            protected override (string token, string secret) ParseResultString(string data)
                => (data.GetValue("oauth_token"),
                    data.GetValue("oauth_token_secret"));

            [IsArgument]
            public string oauth_callback { get; set; } = "oob";
        }
    }
}
