using System.Windows.Media;
using PropertyChanged;

namespace Dalsae.Data
{
    [AddINotifyPropertyChangedInterface]
    public class Skin
    {
		public SolidColorBrush blockOne { get; set; } = new SolidColorBrush(Color.FromRgb(255, 224, 224));
        public SolidColorBrush blockTwo { get; set; } = new SolidColorBrush(Color.FromRgb(255, 207, 207));
        public SolidColorBrush mentionOne { get; set; } = new SolidColorBrush(Color.FromRgb(0xe6, 0xff, 0xe6));
        public SolidColorBrush mentionTwo { get; set; } = new SolidColorBrush(Color.FromRgb(0xff, 0xff, 0xe0));
        public SolidColorBrush tweet { get; set; } = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        public SolidColorBrush retweet { get; set; } = new SolidColorBrush(Color.FromRgb(0x7e, 0x7b, 0xff));
        public SolidColorBrush mention { get; set; } = new SolidColorBrush(Color.FromRgb(0xff, 0x4b, 0x6a));
        public SolidColorBrush defaultColor { get; set; } = new SolidColorBrush(Color.FromRgb(255, 224, 224));
        public SolidColorBrush leaveColor { get; set; } = new SolidColorBrush(Color.FromRgb(0xd9, 0xb0, 0xb0));
        public SolidColorBrush topbar { get; set; } = new SolidColorBrush(Color.FromRgb(255, 207, 207));
        public SolidColorBrush bottomBar { get; set; } = new SolidColorBrush(Color.FromRgb(0xff, 0xbf, 0xbf));
        public SolidColorBrush menuColor { get; set; } = new SolidColorBrush(Color.FromRgb(0xff, 0x4b, 0x6a));
        public SolidColorBrush select { get; set; } = new SolidColorBrush(Color.FromRgb(0xcd, 0xc1, 0xd8));
    }
}
