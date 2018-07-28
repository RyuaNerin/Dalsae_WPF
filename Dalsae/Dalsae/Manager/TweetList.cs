using System.Collections.ObjectModel;
using Dalsae.Twitter.Objects;

namespace Dalsae.Manager
{
    public class DirectMessageList : ObservableCollection<ClientDirectMessage>
    {
        public DirectMessageList() : base()
        {
        }
    }
    public class ListFindUser : ObservableCollection<UserSemi>
    {
        public ListFindUser() : base() { }
    }

    public class TweetTree : ObservableCollection<ClientTweet>
    {
        public TweetTree() : base() { }
    }

    public class TweetList : ObservableCollection<ClientTweet>
    {
        public TweetList() : base()
        {
        }
    }
}
