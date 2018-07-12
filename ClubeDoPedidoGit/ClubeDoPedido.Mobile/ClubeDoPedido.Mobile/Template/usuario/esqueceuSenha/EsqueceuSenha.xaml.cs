using Xamarin.Forms;

namespace ClubeDoPedido.Mobile.Template.usuario.esqueceuSenha
{
    public partial class EsqueceuSenha : ContentPage
    {
        public EsqueceuSenha()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new EsqueceuSenhaLogic();
        }
    }
}
