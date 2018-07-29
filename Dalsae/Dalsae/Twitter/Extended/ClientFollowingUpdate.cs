namespace Dalsae.Twitter.Extended
{
    public class ClientFollowingUpdate
    {
        public ClientRelationship relationship { get; set; }
    }

    public class ClientRelationship
    {
        public ClientTraget target { get; set; }
        public ClientSource source { get; set; }
    }

    public class ClientTraget
    {
        public long id { get; set; }
        public string screen_name { get; set; }
    }

    public class ClientSource
    {
        public bool want_retweets { get; set; }
    }
}
