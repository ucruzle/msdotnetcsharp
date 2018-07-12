using System;
using System.Collections.ObjectModel;
using ClubeDoPedido.Mobile.Enum;
using ClubeDoPedido.Mobile.Interface;
using ClubeDoPedido.Modelo.Modelo;
using ClubeDoPedido.Services.Service;
using Xamarin.Forms;

namespace ClubeDoPedido.Mobile.Template.estabelecimento
{
    public class EstabelecimentoLogic : FactoryNotify
    {
        // Campos
        FactoryTheme _tema;
        PromocaoService _servicoPromocao;
        private readonly INavigation _navigation;
        private readonly INavigationService _navigationService;
        private string _imageUrl;
        private string _nomeFantasia;
        private string _ramoAtividade;
        private string _endereco;
        private string _bannerUrl;
        private string _iconeSeguir;
        private string _textoButtonSeguir;
        private PromocaoDto _itemPromocao;


        // Tema
        public string PrimaryColor { get { return _tema.ColorPrimary; } }
        public string DarkColor { get { return _tema.ColorDark; } }
        public string AccentColor { get { return _tema.ColorAccent; } }
        public string LightColor { get { return _tema.ColorLight; } }
        public string IconeCart { get { return _tema.IconCart; } }
        public string IconeCatalogo { get { return _tema.IconCatalogo; } }
        public string IconeChat { get { return _tema.IconChat; } }


        // Propriedades
        public ObservableCollection<PromocaoDto> Promocoes { get; set; }
        public Command CatalogoCommand { get; set; }
        public Command SeguirCommand { get; set; }

        public string BannerUrl
        {
            get
            {
                return _bannerUrl;
            }
            set
            {
                _bannerUrl = value;
                OnPropertyChanged();
            }
        }

        public string ImageUrl
        {
            get{
                return _imageUrl;
            }
            set{
                _imageUrl = value;
                OnPropertyChanged();
            }
        }

        public string NomeFantasia
        {
            get{
                return _nomeFantasia;
            }
            set {
                _nomeFantasia = value;
                OnPropertyChanged();
            }
        }

        public string RamoAtividade
        {
            get
            {
                return _ramoAtividade;
            }
            set
            {
                _ramoAtividade = value;
                OnPropertyChanged();
            }
        }

        public string Endereco
        {
            get
            {
                return _endereco;
            }
            set
            {
                _endereco = value;
                OnPropertyChanged();
            }
        }

        public string IconeSeguir
        {
            get
            {
                return _iconeSeguir;
            }
            set
            {
                _iconeSeguir = value;
                OnPropertyChanged();
            }
        }
        public string TextoButtonSeguir
        {
            get
            {
                return _textoButtonSeguir;
            }
            set
            {
                _textoButtonSeguir = value;
                OnPropertyChanged();
            }
        }
        public PromocaoDto PromocaoItem
        {
            get
            {
                return _itemPromocao;
            }
            set
            {
                _itemPromocao = value;
                OnPropertyChanged();
            }
        }

        // Construtor
        public EstabelecimentoLogic(EstabelecimentoDto estabelecimento)
        {
            _servicoPromocao = new PromocaoService();
            _iconeSeguir = "curtirSeguir.png";
            _navigationService = DependencyService.Get<INavigationService>();
            CatalogoCommand = new Command(ExecutarCatalogoCommand);
            SeguirCommand = new Command(ExecutarSeguirCommand);
            SetPage(estabelecimento);
            SetTema(estabelecimento.Tema);
            SetIcon(estabelecimento.Seguir);
            SetPromocao(estabelecimento.ParceiroID);
        }
       

        private async void ExecutarCatalogoCommand(object obj) => await _navigationService.NavegarParaTelaCatalogo();

        private void ExecutarSeguirCommand(object obj)
        {
            if (_iconeSeguir == "faseguir18.png")
            {
                _iconeSeguir = "facheck18.png";
                _textoButtonSeguir = "Seguir";
            }
            else
            {
                _textoButtonSeguir = "Seguindo";
            }
        }

        private void SetPage(EstabelecimentoDto estabelecimento)
        {
            _imageUrl = estabelecimento.ImageUrl;
            _nomeFantasia = estabelecimento.NomeFantasia;
            _ramoAtividade = estabelecimento.RamoAtividade;
            _endereco = estabelecimento.Endereco;
            _bannerUrl = estabelecimento.BnnerUrl;
        }

        private void SetPromocao(int idParceiro)
        {
            Promocoes = _servicoPromocao.CarregarPromoocoes(idParceiro);
        }

        private void SetIcon(bool status)
        {
            _iconeSeguir = status == true ? "facheck18.png" : "faseguir18.png";
            _textoButtonSeguir = status == true ? "Seguindo" : "Seguir";
        }

        private void SetTema(int tema)
        {
            var opcao = (Theme)tema;

            switch (opcao)
            {
                case Theme.Principal:
                    break;
                case Theme.Red:
                    _tema = new FactoryTheme(Theme.Red);
                    break;
                case Theme.Pink:
                    _tema = new FactoryTheme(Theme.Pink);
                    break;
                case Theme.Purple:
                    _tema = new FactoryTheme(Theme.Purple);
                    break;
                case Theme.DeepPurple:
                    _tema = new FactoryTheme(Theme.DeepPurple);
                    break;
                case Theme.Indigo:
                    _tema = new FactoryTheme(Theme.Indigo);
                    break;
                case Theme.Blue:
                    _tema = new FactoryTheme(Theme.Blue);
                    break;
                case Theme.LightBlue:
                    _tema = new FactoryTheme(Theme.LightBlue);
                    break;
                case Theme.Cyan:
                    _tema = new FactoryTheme(Theme.Cyan);
                    break;
                case Theme.Teal:
                    _tema = new FactoryTheme(Theme.Teal);
                    break;
                case Theme.Brown:
                    _tema = new FactoryTheme(Theme.Brown);
                    break;
                default:
                    break;
            }
        }

        
    }
}
