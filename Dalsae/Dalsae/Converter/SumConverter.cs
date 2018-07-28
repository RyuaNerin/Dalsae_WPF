using System;
using System.Windows.Data;

namespace Dalsae.Converter
{
    public class SumConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			Type t = values[0].GetType();
			double totalWidth = 0;
			double.TryParse(values[0].ToString(), out totalWidth);
			double parentCount = 0;
			double.TryParse(values[1].ToString(), out parentCount);//자식까지 넓이 제대로 구하려면 부모 수를 -1뺴서
			parentCount--;                                  //최상위 item에서도 20픽셀 안 빠지게 계산 해야함

			double ret = totalWidth - parentCount * 20.0;
			if (ret < 0)
				ret = 10;
			return ret;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
