using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dominio.Dto.Parceiro;
using Dominio.Enum;
using Dominio.Modelo;
using Infraestrutura.Dao;
using Infraestrutura.UnitOfWork;
using Regras.Geral;
using Regras.Negocio;

namespace Interface.Controllers
{
    [RoutePrefix("parceiro")]
    public class ParceiroController : ApiController
    {
        // Campos
        private readonly UnitOfWorkParceiro _unitOfWorkParceiro;

        // Construtor
        public ParceiroController()
        {
            _unitOfWorkParceiro = new UnitOfWorkParceiro(new ContextoDb());
        }


        [HttpGet]
        [Route("BuscaParceiros")]
        public HttpResponseMessage BuscaUsuarios()
        {
            var parceiros = _unitOfWorkParceiro.ParceiroRepositorio.BuscaParceiros();
            return Request.CreateResponse(HttpStatusCode.OK, parceiros);
        }

        // Rotas
        [HttpPost]
        [Route("CadastroNovoParceiro")]
        public HttpResponseMessage CadastroNovoParceiro(ParceiroDto dto)
        {
            if (dto == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            Parceiro parceiro;
            parceiro = RegistrarParceiro.CreateInstance.RegistroNovoParceiro(dto);
            parceiro = _unitOfWorkParceiro.ParceiroRepositorio.CadastrarParceiro(parceiro);

            Token token;
            token = TokenRegras.CreateInstance.RegistrarToken(parceiro.ParceiroID);
            token = _unitOfWorkParceiro.TokenRepositorio.RegistrarToken(token);

            Endereco endereco;
            dto.Endereco.TipoEnderecoID = (int)Dominio.Enum.TipoEndereco.Principal;
            endereco = RegistrarEndereco.CreateInstance.RegistroNovoEndereco(dto.Endereco);
            endereco = _unitOfWorkParceiro.EnderecoRepositorio.CadastrarEndereco(endereco);

            PlanoContratado contrato;
            dto.PlanoContratado.ParceiroID = parceiro.ParceiroID;
            contrato = RegistrarPlanoContratado.CreateInstance.RegistroNovaAssinaturaPlanoContratado(dto.PlanoContratado);
            contrato = _unitOfWorkParceiro.PlanoContratadoRepositorio.NovaAssinaturaPlano(contrato);

            EnderecoVinculo vinculo;
            vinculo = VincularEndereco.CreateInstance.MapVinculo(parceiro.ParceiroID, endereco.EnderecoID, (int)TipoVinculado.ParceiroPrincipal);
            vinculo = _unitOfWorkParceiro.EnderecoVinculoRepositorio.CadastrarEnderecoVinculo(vinculo);

            _unitOfWorkParceiro.Commit();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
