using Newtonsoft.Json;

namespace Dalsae.Twitter.Objects
{
    /// <summary>
    /// 미디어 업로드 후 받는 id 전용
    /// </summary>
    public class ClientMultimedia
    {
        [JsonProperty("media_id")]
        public long MediaId { get; set; }

        [JsonProperty("media_id_string")]
        public string MediaIdString { get; set; }
    }
}
