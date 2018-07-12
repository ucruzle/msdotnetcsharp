using System.Collections.ObjectModel;
using ClubeDoPedido.Mobile.Template.convidarAmigos;
using ClubeDoPedido.Mobile.Template.estabelecimento;
using ClubeDoPedido.Mobile.Template.main.detail;
using ClubeDoPedido.Mobile.Template.main.master;
using ClubeDoPedido.Mobile.Template.promocao;

namespace ClubeDoPedido.Mobile.Configuration.Menu
{
    public class ConfigMenuMasterPage
    {
        private static ObservableCollection<MasterPageItem> MenuList { get; set; }

        public static ObservableCollection<MasterPageItem> GetMenuItens()
        {
            //Configuração do menu
            var pageDetail = new MasterPageItem() { Title = "Início", Icon = "menuhome.png", TargetType = typeof(Detail) };
            var pageEstabelecimento = new MasterPageItem() { Title = "Estabelecimentos", Icon = "menuEstabelecimento.png", TargetType = typeof(Estabelecimento) };
            var pagePromocao = new MasterPageItem() { Title = "Promoções", Icon = "menuPromocoes.png", TargetType = typeof(Promocao) };
            var pageConvideAmigo = new MasterPageItem() { Title = "Convidar Amigos", Icon = "menuConvidarAmigos.png", TargetType = typeof(ConvideAmigo) };
            //var pageConfiguration = new MasterPageItem() { Title = "Configurações", Icon = "menuConfiguracoes.png", TargetType = typeof(Configuracao) };

            MenuList = new ObservableCollection<MasterPageItem>();

            MenuList.Add(pageDetail);
            MenuList.Add(pageEstabelecimento);
            MenuList.Add(pagePromocao);
            MenuList.Add(pageConvideAmigo);
            //MenuList.Add(pageConfiguration);

            return MenuList;
        }
    }
}
