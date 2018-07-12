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
    [ODataRoutePrefix("GeSessoesUsuarios")]
    public class GeSessoesUsuariosController : ODataController
    {
        [Dependency]
        public GeSessaoUsuarioBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<GeSessaoUsuario> _Result = BO.ListarGeSessoesUsuarios().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(Usuario={Usuario})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] string Usuario)
        {
            GeSessaoUsuario _Result = BO.RecuperaGeSessaoUsuario(Usuario);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(GeSessaoUsuario _GeSessaoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarGeSessaoUsuario(_GeSessaoUsuario);

            return Created(_GeSessaoUsuario);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(GeSessaoUsuario _GeSessaoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarGeSessaoUsuario(_GeSessaoUsuario);

            return Updated(_GeSessaoUsuario);
        }

        [ODataRoute("(Usuario={Usuario})")]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete([FromODataUri] string Usuario)
        {
            BO.EliminarGeSessaoUsuario(Usuario);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(GeSessaoUsuario _GeSessaoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<GeSessaoUsuario> _Delta = new Delta<GeSessaoUsuario>();
            _Delta.CopyChangedValues(_GeSessaoUsuario);

            _Delta.Patch(_GeSessaoUsuario);
            return Updated(_GeSessaoUsuario);
        }
    }
}
