using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClubeDoPedido.Mobile.Template
{
    public class FactoryNotify : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
