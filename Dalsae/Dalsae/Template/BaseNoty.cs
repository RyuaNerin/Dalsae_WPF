using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dalsae.Template
{
    public class BaseNoty : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
