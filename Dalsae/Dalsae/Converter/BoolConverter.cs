using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using static Dalsae.DataManager;

namespace Dalsae.Converter
{
    public class BoolConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			//ClientTweet tweet = value as ClientTweet;
			//if (tweet == null) return null;
			object ret = null;
			if (targetType.Name == "FontWeight")
				ret = DataInstence.option.isBoldFont ? FontWeights.Bold : FontWeights.Normal;
			else if (targetType.Name == "TextDecorationCollection")
				ret = (bool)value ? "Strikethrough" : "";
			else if (targetType.Name == "Visibility")
			{
				if(value is bool)
					ret = (bool)value ? Visibility.Visible : Visibility.Collapsed;
				else if(value is string)
				{
					string str = value.ToString();
					if (string.IsNullOrEmpty(str))
						ret = Visibility.Collapsed;
					else
						ret = Visibility.Visible;
				}
			}
			else if (targetType.Name == "Brush")
				ret = (bool)value ? DataInstence.skin.blockOne : DataInstence.skin.blockTwo;
			else if (targetType.Name == "Foreground")
				ret = (bool)value ? DataInstence.skin.mention : DataInstence.skin.tweet;
			return ret;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
