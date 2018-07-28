using System.Collections.Generic;

namespace Dalsae.Manager
{
    public class BlockList
    {
        public long next_cursor { get; set; } = -1;
        public long previous_cursor { get; set; } = -1;
        public HashSet<long> hashBlockUsers { get; set; } = new HashSet<long>();

    }
}
