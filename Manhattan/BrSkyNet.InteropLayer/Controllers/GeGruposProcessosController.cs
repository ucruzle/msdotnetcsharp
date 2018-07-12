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
    [ODataRoutePrefix("GeGruposProcessos")]
    public class GeGruposProcessosController : ODataController
    {
        [Dependency]
        public GeGrupoProcessoBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<GeGrupoProcesso> _Result = BO.ListarGeGruposProcessos().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_empr={CodEmpr} ,cod_grupo={CodGrupo}, cod_proc={CodProc})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] int CodEmpr, [FromODataUri] int CodGrupo, [FromODataUri] int CodProc)
        {
            GeGrupoProcesso _Result = BO.RecuperaGeGrupo(CodEmpr, CodGrupo, CodProc);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(GeGrupoProcesso _GeGrupoProcesso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarGeGrupoProcesso(_GeGrupoProcesso);

            return Created(_GeGrupoProcesso);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(GeGrupoProcesso _GeGrupoProcesso)
        {
            BO.EliminarGeGrupoProcesso(_GeGrupoProcesso);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }
    }
}
