using System.Collections.Generic;

namespace Dalsae.Twitter.Objects
{
    public class ClientEntities
	{
		public List<ClientURL> urls { get; } = new List<ClientURL>();// { get; set; }
		public List<ClientHashtag> hashtags { get; } = new List<ClientHashtag>();// { get; set; }
		public List<ClientUserMentions> user_mentions { get; } = new List<ClientUserMentions>();
		public List<ClientMedia> media { get; } = new List<ClientMedia>();
        //public List<ClientSymbol> symbols = new List<ClientSymbol>();// { get; set; }
    }

    public class ClientExtendedEntities
    {
        public ClientMedia[] media;
    }

    public class ClientURL
    {
        public ClientURL() { }
        public ClientURL(string url, string expandedUrl, string displayUrl)
        {
            this.url = url;
            this.expanded_url = expandedUrl;
            this.display_url = displayUrl;
        }
        public ClientURL(ClientMedia media)
        {
            this.url = media.url;
            this.expanded_url = media.expanded_url;
            this.display_url = media.display_url;
        }
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
    }

    public class ClientHashtag
    {
        public string text { get; set; }
    }

    public class ClientUserMentions//리트윗 한 글의 원 유저 정보. 답변 보낼 때 사용
    {
        public string screen_name { get; set; }
        public string name { get; set; }
        public long id { get; set; }
    }

    public class ClientMultimedia//전송 후 받는 id용
    {
        public string media_id_string { get; set; }
        public long media_id { get; set; }
    }

    public class ClientMedia
    {
        public long id { get; set; }
        public string media_url_https { get; set; }                 //":"https://pbs.twimg.com/media/C06Y8onVEAA6Ktk.jpg",
        public string url { get; set; }                                 //":"https://t.co/gULwuVQFC6",
        public string display_url { get; set; }                         //":"pic.twitter.com/gULwuVQFC6",
        public string expanded_url { get; set; }                        //":"https://twitter.com/umasukesankana/status/814756998243680256/photo/1",
        public string type { get; set; }
        public ClientSize sizes { get; } = new ClientSize();
        public VideoInfo video_info { get; } = new VideoInfo();
    }

    public class ClientSize
    {
        public ClientSizeDetail large { get; } = new ClientSizeDetail();
        public ClientSizeDetail thumb { get; } = new ClientSizeDetail();
        public ClientSizeDetail medium { get; } = new ClientSizeDetail();
        public ClientSizeDetail small { get; } = new ClientSizeDetail();
    }

    public class ClientSizeDetail
    {
        public int w { get; set; }
        public int h { get; set; }
        public string resize { get; set; }
    }

    public class VideoInfo
    {
        public long duration_millis { get; set; }//총 재생시간(ms)
        public List<int> aspect_ratio { get; } = new List<int>();
        public List<Variant> variants { get; } = new List<Variant>();
    }

    public class Variant
    {
        public int bitrate { get; set; }
        public string content_type { get; set; }
        public string url { get; set; }
    }
}
