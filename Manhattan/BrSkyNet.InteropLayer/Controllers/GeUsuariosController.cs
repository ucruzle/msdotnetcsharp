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
    [ODataRoutePrefix("GeUsuarios")]
    public class GeUsuariosController : ODataController
    {
        [Dependency]
        public GeUsuarioBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<GeUsuario> _Result = BO.ListarGeUsuarios().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(usuario={Usuario})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] string Usuario)
        {
            GeUsuario _Result = BO.RecuperaGeUsuario(Usuario);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(GeUsuario _GeUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarGeUsuario(_GeUsuario);

            return Created(_GeUsuario);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(GeUsuario _GeUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarGeUsuario(_GeUsuario);

            return Updated(_GeUsuario);
        }

        [ODataRoute("(usuario={Usuario})")]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(string Usuario)
        {
            BO.EliminarGeUsuario(Usuario);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(GeUsuario _GeUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<GeUsuario> _Delta = new Delta<GeUsuario>();
            _Delta.CopyChangedValues(_GeUsuario);

            _Delta.Patch(_GeUsuario);
            return Updated(_GeUsuario);
        }
    }
}
