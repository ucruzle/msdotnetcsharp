using System;
using System.Collections.ObjectModel;
using ClubeDoPedido.Mobile.Configuration.Menu;
using Xamarin.Forms;

namespace ClubeDoPedido.Mobile.Template.main.master
{
    public partial class Master : ContentPage
    {
        private ObservableCollection<MasterPageItem> _menuList;

        public Master()
        {
            InitializeComponent();
            _menuList = ConfigMenuMasterPage.GetMenuItens();
            NavigationMenu.ItemsSource = _menuList;
            BindingContext = new MasterLogic();
        }

        public void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            App.MasterDetail.Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            App.MasterDetail.IsPresented = false;
            
        }
    }
}
