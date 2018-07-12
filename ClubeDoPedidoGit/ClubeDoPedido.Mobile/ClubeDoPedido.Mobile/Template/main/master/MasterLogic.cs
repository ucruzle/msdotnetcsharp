using ClubeDoPedido.Mobile.Enum;
using ClubeDoPedido.Mobile.Interface;
using Xamarin.Forms;

namespace ClubeDoPedido.Mobile.Template.main.master
{
    public class MasterLogic : FactoryNotify
    {
        //Campos
        FactoryTheme _tema;
        private readonly INavigationService _navigationService;

        //Configuração do Tema
        public string ColorPrimary { get { return _tema.ColorPrimary; } }
        public string ColorDark { get { return _tema.ColorDark; } }
        public string ColorTextIcons { get { return _tema.ColorTextIcons; } }
        public string ColorButtonSecondary { get { return _tema.ColorButtonSecondary; } }

        public MasterLogic()
        {
            _tema = new FactoryTheme(Theme.Principal);
            _navigationService = DependencyService.Get<INavigationService>();

        }
    }
}
