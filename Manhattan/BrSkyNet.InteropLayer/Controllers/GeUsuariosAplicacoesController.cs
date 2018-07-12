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
    [ODataRoutePrefix("GeUsuariosAplicacoes")]
    public class GeUsuariosAplicacoesController : ODataController
    {
        [Dependency]
        public GeUsuarioAplicacaoBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<GeUsuarioAplicacao> _Result = BO.ListarGeUsuariosAplicacoes().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_empr={CodEmpr}, usuario={Usuario}, cod_aplic={CodAplic})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] int CodEmpr, [FromODataUri] string Usuario, [FromODataUri] int CodAplic)
        {
            GeUsuarioAplicacao _Result = BO.RecuperaGeUsuarioAplicacao(CodEmpr, Usuario, CodAplic);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(GeUsuarioAplicacao _GeUsuarioAplicacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarGeUsuarioAplicacao(_GeUsuarioAplicacao);

            return Created(_GeUsuarioAplicacao);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(GeUsuarioAplicacao _GeUsuarioAplicacao)
        {
            BO.EliminarGeUsuarioAplicacao(_GeUsuarioAplicacao);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }
    }
}
