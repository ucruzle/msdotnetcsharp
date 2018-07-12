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
    [ODataRoutePrefix("GeUsuariosGrupos")]
    public class GeUsuariosGruposController : ODataController
    {
        [Dependency]
        public GeUsuarioGrupoBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<GeUsuarioGrupo> _Result = BO.ListarGeUsuariosGrupos().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_empr={CodEmpr}, cod_grupo={CodGrupo}, usuario={Usuario})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] int CodEmpr, [FromODataUri] int CodGrupo, [FromODataUri] string Usuario)
        {
            GeUsuarioGrupo _Result = BO.RecuperaGeUsuarioGrupo(CodEmpr, CodGrupo, Usuario);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(GeUsuarioGrupo _GeUsuarioGrupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarGeUsuarioGrupo(_GeUsuarioGrupo);

            return Created(_GeUsuarioGrupo);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(GeUsuarioGrupo _GeUsuarioGrupo)
        {
            BO.EliminarGeUsuarioGrupo(_GeUsuarioGrupo);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }
    }
}
