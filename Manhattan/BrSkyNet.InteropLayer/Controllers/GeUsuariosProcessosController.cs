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
    [ODataRoutePrefix("GeUsuariosProcessos")]
    public class GeUsuariosProcessosController : ODataController
    {
        [Dependency]
        public GeUsuarioProcessoBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<GeUsuarioProcesso> _Result = BO.ListarGeUsuariosProcessos().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_empr={CodEmpr}, usuario={Usuario}, cod_proc={CodProc})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] int CodEmpr, [FromODataUri] string Usuario, [FromODataUri] int CodProc)
        {
            GeUsuarioProcesso _Result = BO.RecuperaGeUsuarioProcesso(CodEmpr, Usuario, CodProc);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(GeUsuarioProcesso _GeUsuarioProcesso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarGeUsuarioProcesso(_GeUsuarioProcesso);

            return Created(_GeUsuarioProcesso);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(GeUsuarioProcesso _GeUsuarioProcesso)
        {
            BO.EliminarGeUsuarioProcesso(_GeUsuarioProcesso);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }
    }
}
