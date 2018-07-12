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
    [ODataRoutePrefix("RgEstados")]
    public class RgEstadosController : ODataController
    {
        [Dependency]
        public RgEstadoBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<RgEstado> _Result = BO.ListarRgEstados().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(sigla_estado={SiglaEstado})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] string SiglaEstado)
        {
            RgEstado _Result = BO.RecuperaRgEstado(SiglaEstado);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(RgEstado _RgEstado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarRgEstado(_RgEstado);

            return Created(_RgEstado);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(RgEstado _RgEstado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarRgEstado(_RgEstado);

            return Updated(_RgEstado);
        }

        [ODataRoute("(sigla_estado={SiglaEstado})")]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(string SiglaEstado)
        {
            BO.EliminarRgEstado(SiglaEstado);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(RgEstado _RgEstado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<RgEstado> _Delta = new Delta<RgEstado>();
            _Delta.CopyChangedValues(_RgEstado);

            _Delta.Patch(_RgEstado);
            return Updated(_RgEstado);
        }
    }
}
