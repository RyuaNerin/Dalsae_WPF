using System.Windows;

namespace Dalsae.Template
{
    public class DataTemplateParameters : DependencyObject
	{
		public static double GetValueToCompare(DependencyObject obj)
		{
			return (double)obj.GetValue(ValueToCompareProperty);
		}

		public static void SetValueToCompare(DependencyObject obj, double value)
		{
			obj.SetValue(ValueToCompareProperty, value);
		}

		public static readonly DependencyProperty ValueToCompareProperty =
			DependencyProperty.RegisterAttached("ValueToCompare", typeof(double),
												  typeof(DataTemplateParameters));

	}
}
