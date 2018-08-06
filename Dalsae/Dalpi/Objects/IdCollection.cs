using System.Diagnostics;
using Newtonsoft.Json;

namespace Dalpi.Objects
{
    [JsonObject]
    [DebuggerDisplay("Ids : {Ids.Length}")]
    public abstract class IdCollection : ITwitterObject
    {
        [JsonProperty("previous_cursor")]
        public long PreviousCursor { get; set; }

        [JsonProperty("next_cursor")]
        public long NextCursor { get; set; }

        [JsonProperty("ids")]
        public long[] Ids { get; set; }
    }
}
