using System;
using System.Globalization;
using System.Windows.Data;

namespace Dalsae.Converter
{
    public class ContentConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			object ret = null;
			ret = (bool)value ? "언팔로우 하기": "팔로우 하기";
			return ret;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
