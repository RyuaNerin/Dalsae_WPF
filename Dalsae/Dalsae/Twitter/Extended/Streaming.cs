using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalsae.Twitter.Extended
{
    public class ClientStreamDelete
    {
        public StreamDelete delete { get; set; }
    }

    public class StreamDelete
    {
        public Status status { get; set; }
    }

    public class Status
    {
        public long id { get; set; }
    }

    public class StreamDirectMessage
    {
        public ClientDirectMessage direct_message { get; set; }
    }

    public class StreamEvent
    {
        public string Event { get; set; }
        public string created_at { get; set; }
        public StreamSource source { get; set; }
        public User target { get; set; }//유저관련 이벤트일 경우 유저 정보
        public ClientTweet target_object { get; set; }//트윗 관련 이벤트일 경우 트윗 정보
    }

    public class StreamSource//.....???
    {

    }
}
