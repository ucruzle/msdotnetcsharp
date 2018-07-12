using System.Threading.Tasks;
using ClubeDoPedido.Mobile.Interface;
using ClubeDoPedido.Mobile.Template.estabelecimento;
using ClubeDoPedido.Mobile.Template.login;
using ClubeDoPedido.Mobile.Template.main.detail;
using ClubeDoPedido.Mobile.Template.produto.catalogo;
using ClubeDoPedido.Mobile.Template.usuario.conta;
using ClubeDoPedido.Mobile.Template.usuario.esqueceuSenha;
using ClubeDoPedido.Modelo.Modelo;

namespace ClubeDoPedido.Mobile.Service.Navegacao
{
    public class NavigationService : INavigationService
    {
        public async Task NavegarParaTelaCadastroUsuario()
        {
            await App.MasterDetail.Detail.Navigation.PushAsync(new CriarConta());
        }

        public async Task NavegarParaTelaEsqueceuSenha()
        {
            await App.MasterDetail.Detail.Navigation.PushAsync(new EsqueceuSenha());
        }

        public async Task NavegarParaTelaLogin()
        {
            await App.MasterDetail.Detail.Navigation.PushAsync(new Login());
        }

        public async Task NavegarParaTelaDetail()
        {
            App.MasterDetail.IsPresented = false;
            await App.Current.MainPage.Navigation.PushAsync(new Detail());
        }

        public async Task NavegarParaTelaMenuAcesso()
        {
            //await App.Current.MainPage.Navigation.PushAsync(new MenuAcesso());
        }

        public async Task NavegarParaTelaEstabelecimento(EstabelecimentoDto obj)
        {
            await App.MasterDetail.Detail.Navigation.PushAsync(new Estabelecimento(obj));
        }

        public async Task NavegarParaTelaCatalogo()
        {
            await App.MasterDetail.Detail.Navigation.PushAsync(new Catalogo());
        }

        public NavigationService()
        {

        }
    }
}
