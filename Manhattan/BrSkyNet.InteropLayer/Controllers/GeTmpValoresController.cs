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
    [ODataRoutePrefix("GeTmpValores")]
    public class GeTmpValoresController : ODataController
    {
        [Dependency]
        public GeTmpValorBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<GeTmpValor> _Result = BO.ListarGeTmpValores().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(usuario={Usuario})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] string Usuario)
        {
            GeTmpValor _Result = BO.RecuperaGeTmpValor(Usuario);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(GeTmpValor _GeTmpValor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarGeTmpValor(_GeTmpValor);

            return Created(_GeTmpValor);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(GeTmpValor _GeTmpValor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarGeTmpValor(_GeTmpValor);

            return Updated(_GeTmpValor);
        }

        [ODataRoute("(usuario={Usuario})")]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete([FromODataUri] string Usuario)
        {
            BO.EliminarGeTmpValor(Usuario);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(GeTmpValor _GeTmpValor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<GeTmpValor> _Delta = new Delta<GeTmpValor>();
            _Delta.CopyChangedValues(_GeTmpValor);

            _Delta.Patch(_GeTmpValor);
            return Updated(_GeTmpValor);
        }
    }
}
