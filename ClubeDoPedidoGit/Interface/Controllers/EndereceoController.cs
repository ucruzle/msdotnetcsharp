using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dominio.Dto.Endereco;
using Infraestrutura.Dao;
using Infraestrutura.UnitOfWork;
using Regras.Negocio;

namespace Interface.Controllers
{
    [RoutePrefix("endereco")]
    public class EndereceoController : ApiController
    {
        // Campos
        private readonly UnitOfWork _UnitOfWork;

        // Construtor
        public EndereceoController()
        {
            _UnitOfWork = new UnitOfWork(new ContextoDb());
        }

        // Rotas
        [HttpPost]
        [Route("CadastroNovoEndereco")]
        public HttpResponseMessage CadastroNovoEndereco(EnderecoDto endreco)
        {
            if (endreco == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var novoEndereco = RegistrarEndereco.CreateInstance.RegistroNovoEndereco(endreco);
            var resposta = _UnitOfWork.EnderecoRepositorio.CadastrarEndereco(novoEndereco);
            _UnitOfWork.Commit();
            return Request.CreateResponse(HttpStatusCode.OK, resposta);
        }
    }
}
