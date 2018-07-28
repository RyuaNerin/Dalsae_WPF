using System;
using System.Globalization;
using System.Windows.Data;
using static Dalsae.DataManager;

namespace Dalsae.Converter
{
    //그리드에 BackGround랑 Brush가 겹쳐서 분리. 나중에 정리 해야할듯
    public class FontColorConverter:IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			//ClientTweet tweet = value as ClientTweet;
			//if (tweet == null) return null;
			object ret = null;
			if (targetType.Name == "Brush")
				ret = (bool)value ? DataInstence.skin.mention : DataInstence.skin.tweet;
			return ret;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
