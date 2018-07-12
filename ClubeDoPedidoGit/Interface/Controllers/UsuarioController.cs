using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dominio.Dto.Usuario;
using Infraestrutura.Dao;
using Infraestrutura.UnitOfWork;
using Regras.Geral;

namespace Interface.Controllers
{
    [RoutePrefix("usuario")]
    public class UsuarioController : ApiController
    {
        // Campos
        private readonly UnitOfWork _UnitOfWork;

        // Construtor
        public UsuarioController()
        {
            _UnitOfWork = new UnitOfWork(new ContextoDb());
        }

        // Rotas 
        [HttpGet]
        [Route("BuscaUsuarios")]
        public HttpResponseMessage BuscaUsuarios()
        {
            var usuarios = _UnitOfWork.UsuarioRepositorio.BuscaUsuarios();
            return Request.CreateResponse(HttpStatusCode.OK, usuarios);
        }

        [HttpPost]
        [Route("AutenticarUsuario")]
        public HttpResponseMessage AutenticarUsuario(UsuarioAutenticacao dto)
        {
            if (dto == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            dto = UsuarioRegras.CreateInstance.AltenticacaoUsuario(dto);
            var usuario = _UnitOfWork.UsuarioRepositorio.AutenticaUsuario(dto);
            return Request.CreateResponse(HttpStatusCode.OK, usuario);
        }

        [HttpPost]
        [Route("RegistroUsuarioMobile")]
        public HttpResponseMessage CadastroUsuarioMobile(UsuarioMobile dto)
        {
            if (dto == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var usuario = UsuarioRegras.CreateInstance.CadastroNovoUsuarioMobile(dto);
            usuario = _UnitOfWork.UsuarioRepositorio.CadastrarUsuario(usuario);
            _UnitOfWork.Commit();
            return Request.CreateResponse(HttpStatusCode.OK, usuario);
        }

        [HttpPost]
        [Route("CadastroUsuarioParceiro")]
        public HttpResponseMessage CadastroUsuarioParceiro(UsuarioParceiro dto)
        {
            if (dto == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var usuario = UsuarioRegras.CreateInstance.CadastroNovoUsuarioParceiro(dto);
            _UnitOfWork.UsuarioRepositorio.CadastrarUsuario(usuario);
            _UnitOfWork.Commit();
            return Request.CreateResponse(HttpStatusCode.OK, usuario);
        }

        [HttpPut]
        [Route("DesativarUsuario")]
        public HttpResponseMessage DesativarUsuario(UsarioDesativado dto)
        {
            if (dto == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            dto = UsuarioRegras.CreateInstance.DesativarUsuario(dto);
            var resposta = _UnitOfWork.UsuarioRepositorio.DesativarUsuario(dto);
            _UnitOfWork.Commit();
            return Request.CreateResponse(HttpStatusCode.OK, resposta);
        }


    }
}
