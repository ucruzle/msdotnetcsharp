using Xamarin.Forms;

namespace ClubeDoPedido.Mobile.Template.login
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new LoginLogic();
        }
    }
}
