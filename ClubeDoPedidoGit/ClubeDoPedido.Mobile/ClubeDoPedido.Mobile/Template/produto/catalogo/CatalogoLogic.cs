using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ClubeDoPedido.Mobile.Enum;
using ClubeDoPedido.Mobile.Interface;
using ClubeDoPedido.Modelo.Modelo;
using ClubeDoPedido.Services.Service;
using Xamarin.Forms;

namespace ClubeDoPedido.Mobile.Template.produto.catalogo
{
    public class CatalogoLogic : FactoryNotify
    {
        // Campos
        FactoryTheme _tema;
        UsuarioService _servico;
        private readonly INavigationService _navigationService;
        private List<ProdutoDto> _produtoLeft;
        private List<ProdutoDto> _produtoRight;

        // Tema
        public string PrimaryColor { get { return _tema.ColorPrimary; } }
        public string DarkPrimaryColor { get { return _tema.ColorDark; } }
        public string AccentColor { get { return _tema.ColorAccent; } }
        public string TextoIcon { get { return _tema.ColorTextIcons; } }
        public string ColorCard { get { return _tema.ColorDark; } }

        // Propriedades
        public List<ProdutoDto> ItemsColumnLeft
        {
            get
            {
                return _produtoLeft;
            }
            set
            {
                _produtoLeft = value;
                OnPropertyChanged();
            }
        }

        public List<ProdutoDto> ItemsColumnRight
        {
            get
            {
                return _produtoRight;
            }
            set
            {
                _produtoRight = value;
                OnPropertyChanged();
            }
        }

        public Command EntrarCommand { get; set; }

        // Contructs
        public CatalogoLogic()
        {
            _navigationService = DependencyService.Get<INavigationService>();
            _tema = new FactoryTheme(Theme.Principal);
            ItemsColumnLeft = new List<ProdutoDto>();
            ItemsColumnRight = new List<ProdutoDto>();
            LoadCompaniestColumnLeft();
            LoadCompaniestColumnRight();
            
        }

        // Navegação de Páginas

        private ObservableCollection<ProdutoDto> CarregarProdutos(int idParceiro)
        {

            return new ObservableCollection<ProdutoDto> {
                new ProdutoDto {
                    Imagem = "",
                    DescricaoReduzida = "teste",
                    DescricaoDetalhada = "",
                    ValorUnitario = Convert.ToDecimal(20.2),
                    ParceiroID = idParceiro,
                },
            };

        }

        // Métodos
        private void LoadCompaniestColumnLeft()
        {

            _produtoLeft.Add(new ProdutoDto
            {
                Imagem = "",
                DescricaoReduzida = "teste",
                DescricaoDetalhada = "",
                ValorUnitario = Convert.ToDecimal(20.2),
                ParceiroID = 1,
            });

            _produtoLeft.Add(new ProdutoDto
            {
                Imagem = "",
                DescricaoReduzida = "teste",
                DescricaoDetalhada = "",
                ValorUnitario = Convert.ToDecimal(20.2),
                ParceiroID = 1,
            });

            _produtoLeft.Add(new ProdutoDto
            {
                Imagem = "",
                DescricaoReduzida = "teste",
                DescricaoDetalhada = "",
                ValorUnitario = Convert.ToDecimal(20.2),
                ParceiroID = 1,
            });

            _produtoLeft.Add(new ProdutoDto
            {
                Imagem = "",
                DescricaoReduzida = "teste",
                DescricaoDetalhada = "",
                ValorUnitario = Convert.ToDecimal(20.2),
                ParceiroID = 1,
            });
            //var company = new Business.Model.Empresa();

            //company.Titulo = "Tanaka San";
            //company.Descricao = "Restaurante de Culinária Oriental";
            //company.ImageLogo = "tanakaSan.jpg";
            //company.Selecionado = true;
            //company.Fone = "99296-2886";
            //company.CategoriaId = Business.Enum.Categoria.Restaurante.ToString();
            //company.ColorCard = ColorCard;
            //company.CorEmpresa = "#b71c1c";
            //_company.Add(company);

            //company = new Business.Model.Empresa();

            //company.Titulo = "Bob's";
            //company.Descricao = "Lanchonete Fast Food";
            //company.ImageLogo = "Bobs.jpg";
            //company.Selecionado = true;
            //company.Fone = "91401240";
            //company.CategoriaId = Business.Enum.Categoria.Restaurante.ToString();
            //company.ColorCard = ColorCard;
            //company.CorEmpresa = "#303f9f";
            //_company.Add(company);

            //company = new Business.Model.Empresa();

            //company.Titulo = "Habib's";
            //company.Descricao = "Lanchonete Fast Food";
            //company.ImageLogo = "Habibs.jpg";
            //company.Selecionado = true;
            //company.Fone = "91401240";
            //company.CategoriaId = Business.Enum.Categoria.Restaurante.ToString();
            //company.ColorCard = ColorCard;
            //company.CorEmpresa = "#ffff00";
            //_company.Add(company);

            //company = new Business.Model.Empresa();

            //company.Titulo = "Mc donald's";
            //company.Descricao = "Lanchonete Fast Food";
            //company.ImageLogo = "Mc.jpg";
            //company.Selecionado = true;
            //company.Fone = "91401240";
            //company.CategoriaId = Business.Enum.Categoria.Restaurante.ToString();
            //company.ColorCard = ColorCard;
            //company.CorEmpresa = "#e53935";
            //_company.Add(company);

        }
        private void LoadCompaniestColumnRight()
        {
            _produtoRight.Add(new ProdutoDto
            {
                Imagem = "",
                DescricaoReduzida = "teste",
                DescricaoDetalhada = "",
                ValorUnitario = Convert.ToDecimal(20.2),
                ParceiroID = 1,
            });

            _produtoRight.Add(new ProdutoDto
            {
                Imagem = "",
                DescricaoReduzida = "teste",
                DescricaoDetalhada = "",
                ValorUnitario = Convert.ToDecimal(20.2),
                ParceiroID = 1,
            });

            _produtoRight.Add(new ProdutoDto
            {
                Imagem = "",
                DescricaoReduzida = "teste",
                DescricaoDetalhada = "",
                ValorUnitario = Convert.ToDecimal(20.2),
                ParceiroID = 1,
            });

            _produtoRight.Add(new ProdutoDto
            {
                Imagem = "",
                DescricaoReduzida = "teste",
                DescricaoDetalhada = "",
                ValorUnitario = Convert.ToDecimal(20.2),
                ParceiroID = 1,
            });

            //var company1 = new Business.Model.Empresa();

            //company1.Titulo = "Emi Burger";
            //company1.Descricao = "Hamburgueria Gourmet";
            //company1.ImageLogo = "EmiBurguer.jpg";
            //company1.Selecionado = true;
            //company1.Fone = "992236096";
            //company1.CategoriaId = Business.Enum.Categoria.Restaurante.ToString();
            //company1.ColorCard = ColorCard;
            //company1.CorEmpresa = "#b71c1c";
            //_company1.Add(company1);

            //company1 = new Business.Model.Empresa();

            //company1.Titulo = "Pizza Hut";
            //company1.Descricao = "Pizzaria Fast Food";
            //company1.ImageLogo = "PizzaHut.jpg";
            //company1.Selecionado = true;
            //company1.Fone = "992236096";
            //company1.CategoriaId = Business.Enum.Categoria.Restaurante.ToString();
            //company1.ColorCard = ColorCard;
            //company1.CorEmpresa = "#b71c1c";
            //_company1.Add(company1);


            //company1 = new Business.Model.Empresa();

            //company1.Titulo = "SUBWAY";
            //company1.Descricao = "Lanches Naturais";
            //company1.ImageLogo = "SubWay.jpg";
            //company1.Selecionado = true;
            //company1.Fone = "992236096";
            //company1.CategoriaId = Business.Enum.Categoria.Restaurante.ToString();
            //company1.ColorCard = ColorCard;
            //company1.CorEmpresa = "#b71c1c";
            //_company1.Add(company1);

        }
    }
}
