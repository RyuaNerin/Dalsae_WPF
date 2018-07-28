using System.Windows;
using System.Windows.Input;

namespace Dalsae.WindowAndControl
{
    /// <summary>
    /// HelpWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HelpWindow : Window
	{
		public HelpWindow()
		{
			InitializeComponent();
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
				Close();
		}
	}
}
