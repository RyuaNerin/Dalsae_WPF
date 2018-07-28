using System;
using System.Globalization;
using System.Windows.Data;
using Dalsae.Template;
using Dalsae.Twitter.Objects;
using static Dalsae.DataManager;

namespace Dalsae.Converter
{
    /// <summary>
    /// 배경 색 컨버터
    /// </summary>
    public class BackgroundConvert : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			object ret = null;

			UIProperty uiProperty = null;
			if (value is ClientTweet)
				uiProperty = ((ClientTweet)value).uiProperty;
			else if (value is ClientDirectMessage)
				uiProperty = ((ClientDirectMessage)value).uiProperty;

			if (uiProperty == null)
				return null;

			if (uiProperty.isBackOne)
				ret = DataInstence.skin.blockOne;
			else
				ret = DataInstence.skin.blockTwo;
			return ret;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
