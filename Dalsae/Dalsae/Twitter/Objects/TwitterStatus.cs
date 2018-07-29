using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using PropertyChanged;

namespace Dalsae.Twitter.Objects
{
    [JsonObject]
    [DebuggerDisplay("Status {Id} - @{User.ScreenName}: {Text}")]
    [AddINotifyPropertyChangedInterface]
    public class Status
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("in_reply_to_status_id", NullValueHandling = NullValueHandling.Ignore)]
        public long InReplyToStatusId { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("full_text")]
        public string FullText { get; set; }

        [JsonProperty("entities")]
        public StatusEntities Entities { get; set; }

        [JsonProperty("extended_entities")]
        public StatusEntities ExtendedEntities { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        ///////////////////////////////////////////////////////

        [JsonProperty("truncated")]
        public bool Truncated { get; set; }

        [JsonProperty("extended_tweet")]
        public ExtendedTweet ExtendedTweet { get; set; }

        ///////////////////////////////////////////////////////

        [JsonProperty("retweeted")]
        public bool Retweeted { get; set; }

        [JsonProperty("retweeted_status")]
        public Status RetweetedStatus { get; set; }

        ///////////////////////////////////////////////////////

        [JsonProperty("is_quote_status")]
        public long IsQuoteStatus { get; set; }

        [JsonProperty("quoted_status_id", NullValueHandling = NullValueHandling.Ignore)]
        public long QuotedStatusId { get; set; }

        [JsonProperty("quoted_status")]
        public Status QuotedStatus { get; set; }

        ///////////////////////////////////////////////////////

        [JsonProperty("favorited")]
        public bool Favorited { get; set; }

        [JsonProperty("favorite_count")]
        public int FavoriteCount { get; set; }

        ///////////////////////////////////////////////////////

        [JsonProperty("source")]
        public string Source { get; set; }

        //////////////////////////////////////////////////

        [JsonProperty("current_user_retweet")]
        public CurrentUserRetweet CurrentUserRetweet { get; set; }
    }

    [JsonObject]
    public class CurrentUserRetweet
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }

    [JsonObject]
    public class ExtendedTweet
    {
        [JsonProperty("full_text")]
        public string FullText { get; set; }

        [JsonProperty("entities")]
        public StatusEntities Entities { get; set; }

        [JsonProperty("extended_entities")]
        public StatusEntities ExtendedEntities { get; set; }
    }

    [JsonObject]
    public class StatusEntities
    {
        [JsonProperty("urls")]
        public UrlEntity[] Urls { get; set; }

        [JsonProperty("user_mentions")]
        public MentionEntity[] Mentions { get; set; }

        [JsonProperty("hashtags")]
        public HashTagEntity[] HashTags { get; set; }

        [JsonProperty("media")]
        public Media[] Media { get; set; }
    }

    [JsonObject]
    public class UrlEntity
    {
        [JsonProperty("indices")]
        public int[] Indices { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("display_url")]
        public string DisplayUrl { get; set; }

        [JsonProperty("expanded_url")]
        public string ExpandedUrl { get; set; }
    }

    [JsonObject]
    public class MentionEntity
    {
        [JsonProperty("indices")]
        public int[] Indices { get; set; }

        [JsonProperty("id_str")]
        public string Id { get; set; }

        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    [JsonObject]
    public class HashTagEntity
    {
        [JsonProperty("indices")]
        public int[] Indices { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    [JsonObject]
    public class Media
    {
        [JsonProperty("indices")]
        public int[] Indices { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("display_url")]
        public string DisplayUrl { get; set; }

        [JsonProperty("expanded_url")]
        public string ExpandedUrl { get; set; }

        [JsonProperty("media_url")]
        public string MediaUrl { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("sizes")]
        public ClientSize Sizes { get; set; }

        [JsonProperty("video_info")]
        public VideoInfo VideoInfo { get; set; }
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
