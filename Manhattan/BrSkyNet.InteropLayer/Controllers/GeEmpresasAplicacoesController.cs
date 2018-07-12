using BrSkyNet.BusinessLogicLayer.BusinessObjects;
using BrSkyNet.ModelLayer.Entities;
using Microsoft.Practices.Unity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;

namespace BrSkyNet.InteropLayer.Controllers
{
    [ODataRoutePrefix("GeEmpresasAplicacoes")]
    public class GeEmpresasAplicacoesController : ODataController
    {
        [Dependency]
        public GeEmpresaAplicacaoBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<GeEmpresaAplicacao> _Result = BO.ListarGeEmpresasAplicacoes().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_empr={CodEmpr} ,cod_aplic={CodAplic})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get(int CodEmpr, int CodAplic)
        {
            GeEmpresaAplicacao _Result = BO.RecuperarGeEmpresaAplicacao(CodEmpr, CodAplic);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(GeEmpresaAplicacao _GeEmpresaAplicacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarGeEmpresaAplicacao(_GeEmpresaAplicacao);

            return Created(_GeEmpresaAplicacao);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(GeEmpresaAplicacao _GeEmpresaAplicacao)
        {
            BO.EliminarGeEmpresaAplicacao(_GeEmpresaAplicacao);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }
    }
}
