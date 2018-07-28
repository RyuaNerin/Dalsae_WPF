namespace Dalsae.Template
{
    public class WidthNoti:BaseNoty
	{
		private double _width;
		public double Width
		{
			get { return _width; }
			set { _width = value; OnPropertyChanged("Width"); }
		}
	}
}
