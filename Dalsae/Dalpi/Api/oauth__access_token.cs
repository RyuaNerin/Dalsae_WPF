namespace Dalpi.Api
{
    public static class oauth
    {
        public class access_token : BaseParam<(string token, string secret, long userId, string screen_name)>
        {
            public access_token()
                : base("POST", "https://api.twitter.com/oauth/access_token")
            { }

            protected override (string token, string secret, long userId, string screen_name) ParseResultString(string data)
                => (data.GetValue("oauth_token"),
                    data.GetValue("oauth_token_secret"),
                    long.Parse(data.GetValue("user_id")),
                    data.GetValue("screen_name"));

            [IsArgument]
            public string oauth_verifier { get; set; }
        }
    }
}
