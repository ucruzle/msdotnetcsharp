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
    [ODataRoutePrefix("RgStatusCollection")]
    public class RgStatusCollectionController : ODataController
    {
        [Dependency]
        public RgStatusBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<RgStatus> _Result = BO.ListarRgStatusCollection().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_status={CodStatus})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] int CodStatus)
        {
            RgStatus _Result = BO.RecuperarRgStatus(CodStatus);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(RgStatus _RgStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarRgStatus(_RgStatus);

            return Created(_RgStatus);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(RgStatus _RgStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarRgStatus(_RgStatus);

            return Updated(_RgStatus);
        }

        [ODataRoute("(cod_status={CodStatus})")]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete([FromODataUri] int CodStatus)
        {
            BO.EliminarRgStatus(CodStatus);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(RgStatus _RgStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<RgStatus> _Delta = new Delta<RgStatus>();
            _Delta.CopyChangedValues(_RgStatus);

            _Delta.Patch(_RgStatus);
            return Updated(_RgStatus);
        }
    }
}
