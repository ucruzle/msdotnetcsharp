using ClubeDoPedido.Mobile.Template.main.detail;
using ClubeDoPedido.Mobile.Template.main.master;
using Xamarin.Forms;

namespace ClubeDoPedido.Mobile.Template.main
{
    public partial class MainPage : MasterDetailPage
    {
        public static MainPage MainPageNavigation { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Master = new Master();
            Detail = new NavigationPage(new Detail());
            App.MasterDetail = this;
        }
    }
}
