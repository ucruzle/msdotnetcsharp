
using Xamarin.Forms;

namespace ClubeDoPedido.Mobile.Template.produto.catalogo
{
    public partial class Catalogo : ContentPage
    {
        public Catalogo()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new CatalogoLogic();
        }

    }
}
