using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using static Dalsae.DataManager;

namespace Dalsae.Converter
{
    public class DeahwaConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			//ClientTweet tweet = value as ClientTweet;
			//if (tweet == null) return null;
			object ret = null;
			if (targetType.Name == "Brush")
				ret = (bool)value ? DataInstence.skin.mentionOne : DataInstence.skin.mentionTwo;
			else if (targetType.Name == "Visibility")
				ret = (bool)value ? Visibility.Visible : Visibility.Collapsed;
			return ret;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
