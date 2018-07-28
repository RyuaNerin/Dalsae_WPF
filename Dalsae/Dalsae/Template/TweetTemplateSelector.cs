using System.Windows;
using System.Windows.Controls;
using Dalsae.Twitter.Objects;

namespace Dalsae.Template
{
    public class TweetTemplateSelector : DataTemplateSelector
	{
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			FrameworkElement element = container as FrameworkElement;

			if (element != null && item != null && item is ClientTweet)
			{
				ClientTweet tweet = item as ClientTweet;
				if (tweet.originalTweet == null)
					return element.FindResource("moreButton") as DataTemplate;
				else if (tweet.isRetweet)
					return element.FindResource("retweetControl") as DataTemplate;
				else
					return element.FindResource("tweetControl") as DataTemplate;

			}

			return null;
		}
	}
}
