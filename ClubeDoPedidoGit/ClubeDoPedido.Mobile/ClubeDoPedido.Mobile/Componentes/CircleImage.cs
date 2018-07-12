using System.Windows.Input;
using Xamarin.Forms;

namespace ClubeDoPedido.Mobile.Componentes
{
    public class CircleImage : Image
    {
        public static BindableProperty CommandPropert =
            BindableProperty.Create<CircleImage, ICommand>(b => b.Command, default(ICommand));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandPropert); }
            set { SetValue(CommandPropert, value); }
        }


        public CircleImage()
        {
            var gesto = new TapGestureRecognizer();
            gesto.Tapped += (sender, e) => {
                if (Command != null && Command.CanExecute(null))
                {
                    Command.CanExecute(null);
                }
            };
            GestureRecognizers.Add(gesto);
        }
    }
}
