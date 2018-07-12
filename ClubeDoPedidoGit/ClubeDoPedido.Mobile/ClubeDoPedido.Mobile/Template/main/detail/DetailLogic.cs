using System.Collections.ObjectModel;
using ClubeDoPedido.Mobile.Interface;
using ClubeDoPedido.Modelo.Modelo;
using Xamarin.Forms;

namespace ClubeDoPedido.Mobile.Template.main.detail
{
    public class DetailLogic : FactoryNotify
    {
        // Campos
        private readonly INavigationService navigationService;
        private EstabelecimentoDto _itemEstabelecimento;

        // Propriedades
        public ObservableCollection<BannerDto> Banners { get; set; }
        public ObservableCollection<EstabelecimentoDto> Estabelecimentos { get; set; }
        public Command EntrarCommand { get; set; }
        public Command CallEstabelecimento { get; set; }
        public EstabelecimentoDto EstabelecimentoItem
        {
            get {
                return _itemEstabelecimento;
            }
            set{
                _itemEstabelecimento = value;
                OnPropertyChanged();
                ExecuteCallEstabelecimento(_itemEstabelecimento);
            }
        }

        // Construtor
        public DetailLogic()
        {
            Banners = CarregarBanners();
            Estabelecimentos = CarregarEstabelecimentos();
            EntrarCommand = new Command(ExecuteEntrarCommand);
            navigationService = DependencyService.Get<INavigationService>();
        }

        // Navegação de Páginas
        private async void ExecuteEntrarCommand(object obj) => await navigationService.NavegarParaTelaLogin();
        private async void ExecuteCallEstabelecimento(EstabelecimentoDto obj) => await navigationService.NavegarParaTelaEstabelecimento(obj);

        // Métodos
        private ObservableCollection<BannerDto> CarregarBanners()
        {
            return new ObservableCollection<BannerDto> {
                new BannerDto {
                    ImageUrl = "bk.jpg",
                    NomeProduto = "Big king",
                    NomeEstabelecimento = "Burger King",
                    PecoVenda = "R$ 19,90"
                },
                new BannerDto {
                    ImageUrl = "bk2.jpg",
                    NomeProduto = "Combo king",
                    NomeEstabelecimento = "Burger King",
                    PecoVenda = "R$ 15.00"
                },
                new BannerDto {
                    ImageUrl = "bkEverest.jpg",
                    NomeProduto = "BK Everest",
                    NomeEstabelecimento = "Burger King",
                    PecoVenda = "R$ 6.90"
                },
                new BannerDto {
                    ImageUrl = "cacaushow.jpg",
                    NomeProduto = "Combos Cacau",
                    NomeEstabelecimento = "Cacau Show",
                    PecoVenda = "R$ 5.00"
                },
                new BannerDto {
                    ImageUrl = "temaki.jpg",
                    NomeProduto = "Temaki de Salmão",
                    NomeEstabelecimento = "Tanaka San",
                    PecoVenda = "R$ 14.90"
                }
            };
        }

        private ObservableCollection<EstabelecimentoDto> CarregarEstabelecimentos()
        {
            return new ObservableCollection<EstabelecimentoDto> {
                new EstabelecimentoDto {
                    ParceiroID = 1,
                    BnnerUrl = "bannerPrincipalBurgerKing.jpg",
                    ImageUrl = "logoBK.png",
                    NomeFantasia = "Burguer King",
                    Avaliacao = 4.3,
                    RamoAtividade = "Hambúrgueres - Lanches - Sanduíches",
                    Endereco = "Avenida Presidente Kennedy, 12345, Ribeirânia - 618Km",
                    Seguir = true,
                    Tema = 1
                },
                new EstabelecimentoDto {
                    ParceiroID = 2,
                    BnnerUrl = "bannerPrincipalEmiBurger.jpg",
                    ImageUrl = "logoEmiBurger.jpg",
                    NomeFantasia = "Emi Burger",
                    Avaliacao = 4.1,
                    RamoAtividade = "Hambúrgueres - Lanches - Sanduíches",
                    Endereco = "Rua 9 (nove), 818a, Centro - Orlândia",
                    Seguir = false,
                    Tema = 1
                },
                new EstabelecimentoDto {
                    ParceiroID = 3,
                    BnnerUrl = "bannerPrincipalCafe.jpg",
                    ImageUrl = "logoCafe.png",
                    NomeFantasia = "Café",
                    Avaliacao = 3.2,
                    RamoAtividade = "Cafeteria",
                    Endereco = "Rua 9 (nove), 818a, Centro - Orlândia",
                    Seguir = true,
                    Tema = 17
                },
                new EstabelecimentoDto {
                    ParceiroID = 4,
                    BnnerUrl = "bannerPrincipalIpanema.jpg",
                    ImageUrl = "ipanema.jpg",
                    NomeFantasia = "Ipanema",
                    Avaliacao = 4.3,
                    RamoAtividade = "Comércio - Varejo  - Lojas",
                    Endereco = "Avenida Presidente Kennedy, 12345, Ribeirânia - 618Km",
                    Seguir = false,
                    Tema = 2
                },
                new EstabelecimentoDto {
                    ParceiroID = 5,
                    BnnerUrl = "bannerPrincipalCarrefour.jpg",
                    ImageUrl = "carrefour.png",
                    NomeFantasia = "Carrefour",
                    Avaliacao = 4.1,
                    RamoAtividade = "Supermercados - Mercearia - Hortifrutes",
                    Endereco = "Avenida Presidente Kennedy, 12345, Ribeirânia - 618Km",
                    Seguir = false,
                    Tema = 5
                },
                new EstabelecimentoDto {
                    ParceiroID = 6,
                    BnnerUrl = "bannerPrincipalDrogaRaia.jpg",
                    ImageUrl = "drogaRaia.jpg",
                    NomeFantasia = "Droga Raia",
                    Avaliacao = 3.5,
                    RamoAtividade = "Farmácias",
                    Endereco = "Avenida Presidente Kennedy, 12345, Ribeirânia - 618Km",
                    Seguir = false,
                    Tema = 9
                }
            };
        }

    }
}
