using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Dalsae.Twitter.Objects;
using static Dalsae.DataManager;

namespace Dalsae.Converter
{
    public class PreviewConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			object ret = null;
			if (targetType.Name == "ImageSource")
			{
				ClientTweet tweet = value as ClientTweet;
				if (tweet == null) return null;
				if (tweet.isPhoto)
				{
					string param = parameter?.ToString() ?? "";
					if (param == "one" && tweet.mediaEntities.media.Count > 0)
						ret = $"{tweet.mediaEntities.media[0].media_url_https}:thumb";
					else if (param == "two" && tweet.mediaEntities.media.Count > 1)
						ret = $"{tweet.mediaEntities.media[1].media_url_https}:thumb";
					else if (param == "three" && tweet.mediaEntities.media.Count > 2)
						ret = $"{tweet.mediaEntities.media[2].media_url_https}:thumb";
					else if (param == "four" && tweet.mediaEntities.media.Count > 3)
						ret = $"{tweet.mediaEntities.media[3].media_url_https}:thumb";
					else
						ret = null;
				}
				else if(tweet.isMovie)//동영상 썸네일
				{
					string param = parameter?.ToString() ?? "";
					if (param == "one" && tweet.extended_entities?.media.Count > 0)
						ret = $"{tweet.extended_entities.media[0].media_url_https}:thumb";
					else
						ret = null;
				}
			}
			else if (targetType.Name == "Visibility")
			{
				ret = DataInstence.option.isShowPreview ? Visibility.Visible : Visibility.Collapsed;
			}
			return ret;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
