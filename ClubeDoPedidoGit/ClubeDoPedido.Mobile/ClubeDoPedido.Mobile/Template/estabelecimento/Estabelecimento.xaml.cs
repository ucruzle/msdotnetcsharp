using ClubeDoPedido.Modelo.Modelo;
using Xamarin.Forms;

namespace ClubeDoPedido.Mobile.Template.estabelecimento
{
    public partial class Estabelecimento : ContentPage
    {
        public Estabelecimento(EstabelecimentoDto estabelecimento)
        {
            InitializeComponent();

            BindingContext = new EstabelecimentoLogic(estabelecimento);
            NavigationPage.SetHasNavigationBar(this, false);
        }

       
    }
}
