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
    [ODataRoutePrefix("RgTiposRgs")]
    public class RgTiposRgsController : ODataController
    {
        [Dependency]
        public RgTipoRgBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<RgTipoRg> _Result = BO.ListarRgTiposRgs().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(tipo_rg={TipoRg})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] string TipoRg)
        {
            RgTipoRg _Result = BO.RecuperarRgTipoRg(TipoRg);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(RgTipoRg _RgTipoRg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarRgTipoRg(_RgTipoRg);

            return Created(_RgTipoRg);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(RgTipoRg _RgTipoRg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarRgTipoRg(_RgTipoRg);

            return Updated(_RgTipoRg);
        }

        [ODataRoute("(tipo_rg={TipoRg})")]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete([FromODataUri] string TipoRg)
        {
            BO.EliminarRgTipoRg(TipoRg);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(RgTipoRg _RgTipoRg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<RgTipoRg> _Delta = new Delta<RgTipoRg>();
            _Delta.CopyChangedValues(_RgTipoRg);

            _Delta.Patch(_RgTipoRg);
            return Updated(_RgTipoRg);
        }
    }
}
