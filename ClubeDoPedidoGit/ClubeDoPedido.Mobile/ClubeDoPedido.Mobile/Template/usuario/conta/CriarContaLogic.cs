using System;
using ClubeDoPedido.Mobile.Enum;
using ClubeDoPedido.Mobile.Interface;
using ClubeDoPedido.Modelo.Modelo;
using ClubeDoPedido.Services.Service;
using Xamarin.Forms;

namespace ClubeDoPedido.Mobile.Template.usuario.conta
{
    public class CriarContaLogic : FactoryNotify
    {
        // Campos
        FactoryTheme _tema;
        UsuarioService _servico;
        private readonly INavigationService _navigationService;
        private string _nome;
        private string _email;
        private string _celular;
        private string _senha;
        private string _confirmaSenha;

        // Configuração do Tema
        public string ColorPrimary { get { return _tema.ColorPrimary; } }
        public string ColorDark { get { return _tema.ColorDark; } }
        public string ColorTextIcons { get { return _tema.ColorTextIcons; } }
        public string ColorButtonSecondary { get { return _tema.ColorButtonSecondary; } }
        public string ColorDivider { get { return _tema.ColorDivider; } }

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

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string Celular
        {
            get
            {
                return _celular;
            }
            set
            {
                _celular = value;
                OnPropertyChanged();
            }
        }

        public string Senha
        {
            get
            {
                return _senha;
            }
            set
            {
                _senha = value;
                OnPropertyChanged();
            }
        }

        public string ConfirmarSenha
        {
            get
            {
                return _confirmaSenha;
            }
            set
            {
                _confirmaSenha = value;
                OnPropertyChanged();
            }
        }

        // Propriedades Botões
        public Command CadastrarCommand { get; private set; }
        public Command TermosUsoCommand { get; set; }

        // Construtor
        public CriarContaLogic()
        {
            _servico = new UsuarioService();
            _tema = new FactoryTheme(Theme.Principal);
            _navigationService = DependencyService.Get<INavigationService>();
            CadastrarCommand = new Command(ExecuteCadastrarCommand);
            TermosUsoCommand = new Command(ExecuteTermosUsoCommand);
        }

        // Métodos
        private void ExecuteTermosUsoCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private async void ExecuteCadastrarCommand(object obj)
        {
            var usuario = new UsuarioDto
            {
                Nome = Nome,
                Email = Email,
                Celular = Celular,
                Senha = Senha
            };

            await _servico.RegistrarUsuario(usuario);
            LimparCampos();
        }

        private void LimparCampos()
        {
            Nome = "";
            Email = "";
            Celular = "";
            Senha = "";
            ConfirmarSenha = "";
        }
    }
}
