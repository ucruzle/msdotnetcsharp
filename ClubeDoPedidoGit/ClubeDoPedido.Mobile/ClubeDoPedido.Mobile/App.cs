using System.Reflection;
using ClubeDoPedido.Mobile.Interface;
using ClubeDoPedido.Mobile.Resources;
using ClubeDoPedido.Mobile.Service.Navegacao;
using ClubeDoPedido.Mobile.Template.main;
using Xamarin.Forms;

namespace ClubeDoPedido.Mobile
{
    public class App : Application
    {
        public static MasterDetailPage MasterDetail { get; set; }

        public App()
        {
            // Injeta dependencias
            DependencyService.Register<INavigationService, NavigationService>();

            MainPage = new MainPage();
        }

        void LoadDynamicResources(IDynamicResources resources)
        {
            if (Resources == null)
                Resources = new ResourceDictionary();

            var propriedades = resources.GetType().GetRuntimeProperties();
            foreach (var prop in propriedades)
            {
                Resources.Add(prop.Name, prop.GetValue(resources));
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
