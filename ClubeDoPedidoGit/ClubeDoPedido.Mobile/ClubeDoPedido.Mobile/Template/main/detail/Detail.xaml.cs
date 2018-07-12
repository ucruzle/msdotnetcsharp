
using Xamarin.Forms;

namespace ClubeDoPedido.Mobile.Template.main.detail
{
    public partial class Detail : ContentPage
    {
        public Detail()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            BindingContext = new DetailLogic();
        }
    }
}
