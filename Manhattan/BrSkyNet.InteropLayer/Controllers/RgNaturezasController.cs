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
    [ODataRoutePrefix("RgNaturezas")]
    public class RgNaturezasController : ODataController
    {
        [Dependency]
        public RgNaturezaBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<RgNatureza> _Result = BO.ListarRgNaturezas().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_natureza={CodNatureza})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] int CodNatureza)
        {
            RgNatureza _Result = BO.RecuperarRgNatureza(CodNatureza);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(RgNatureza _RgNatureza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarRgNatureza(_RgNatureza);

            return Created(_RgNatureza);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(RgNatureza _RgNatureza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarRgNatureza(_RgNatureza);

            return Updated(_RgNatureza);
        }

        [ODataRoute("(cod_natureza={CodNatureza})")]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(int CodNatureza)
        {
            BO.EliminarRgNatureza(CodNatureza);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(RgNatureza _RgNatureza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<RgNatureza> _Delta = new Delta<RgNatureza>();
            _Delta.CopyChangedValues(_RgNatureza);

            _Delta.Patch(_RgNatureza);
            return Updated(_RgNatureza);
        }
    }
}
