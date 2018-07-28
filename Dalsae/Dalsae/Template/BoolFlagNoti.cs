namespace Dalsae.Template
{
    public class BoolFlagNoti : BaseNoty
	{
		private bool _isOn=false;
		public bool isOn
		{
			get { return _isOn; }
			set { _isOn = value; OnPropertyChanged("isOn"); }
		}
	}
}
