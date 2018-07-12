using System.Threading.Tasks;
using ClubeDoPedido.Modelo.Modelo;

namespace ClubeDoPedido.Mobile.Interface
{
    public interface INavigationService
    {
        Task NavegarParaTelaMenuAcesso();
        Task NavegarParaTelaLogin();
        Task NavegarParaTelaCadastroUsuario();
        Task NavegarParaTelaEsqueceuSenha();
        Task NavegarParaTelaDetail();
        Task NavegarParaTelaEstabelecimento(EstabelecimentoDto obj);
        Task NavegarParaTelaCatalogo();
    }
}
