using System;
using ClubeDoPedido.Mobile.Enum;
using ClubeDoPedido.Mobile.Interface;
using ClubeDoPedido.Services.Service;
using Xamarin.Forms;

namespace ClubeDoPedido.Mobile.Template.login
{
    public class LoginLogic : FactoryNotify
    {
        // Campos
        FactoryTheme _tema;
        UsuarioService servico;
        private readonly INavigationService _navigationService;
        private string _nome;


        // Configuração do Tema
        public string ColorPrimary { get { return _tema.ColorPrimary; } }
        public string ColorDark { get { return _tema.ColorDark; } }
        public string ColorTextIcons { get { return _tema.ColorTextIcons; } }
        public string ColorButtonSecondary { get { return _tema.ColorButtonSecondary; } }

        // Properties
        public string Nome
        {
            get
            {
                return _nome;
            }
            set
            {
                _nome = value;
                OnPropertyChanged();
            }
        }

        // Propriedades Botões
        public Command EntrarCommand { get; private set; }
        public Command CadastrarCommand { get; set; }
        public Command EsqueceuSenhaCommand { get; set; }

        // Contrutor
        public LoginLogic()
        {
            servico = new UsuarioService();
            _tema = new FactoryTheme(Theme.Principal);
            _navigationService = DependencyService.Get<INavigationService>();
            EntrarCommand = new Command(ExecutarEntrarCommand);
            CadastrarCommand = new Command(ExecutarCadastrarCommand);
            EsqueceuSenhaCommand = new Command(ExecutarEsqueceuSenhaCommand);
        }

        // Navegação Tela
        private async void ExecutarCadastrarCommand(object obj) => await _navigationService.NavegarParaTelaCadastroUsuario();
        private async void ExecutarEsqueceuSenhaCommand(object obj) => await _navigationService.NavegarParaTelaEsqueceuSenha();

        // Métodos
        private async void ExecutarEntrarCommand(object obj)
        {
            var result = await servico.BuscaUsuarios();
        }
    }
}
