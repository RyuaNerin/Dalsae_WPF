using System.Windows;
using System.Windows.Controls;
using Dalsae.Twitter.Objects;

namespace Dalsae.Template
{
    public class DeahwaTemplate : DataTemplateSelector
	{
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			FrameworkElement element = container as FrameworkElement;

			if (element != null && item != null && item is ClientTweet)
			{
				ClientTweet tweet = item as ClientTweet;
				if (tweet != null)
					return element.FindResource("dhTweet") as DataTemplate;
			}

			return null;
		}
	}
}
