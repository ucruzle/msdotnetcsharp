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
    [ODataRoutePrefix("RgRegGeraisNaturezas")]
    public class RgRegGeraisNaturezasController : ODataController
    {
        [Dependency]
        public RgRegGeralNaturezaBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<RgRegGeralNatureza> _Result = BO.ListarRgRegGeraisNaturezas().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_empr={CodEmpr}, cod_rg={CodRg}, cod_natureza={CodNatureza})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] int CodEmpr, [FromODataUri] int CodRg, [FromODataUri] int CodNatureza)
        {
            RgRegGeralNatureza _Result = BO.RecuperarRgRegGeralNatureza(CodEmpr, CodRg, CodNatureza);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(RgRegGeralNatureza _RgRegGeralNatureza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarRgRegGeralNatureza(_RgRegGeralNatureza);

            return Created(_RgRegGeralNatureza);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(RgRegGeralNatureza _RgRegGeralNatureza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarRgRegGeralNatureza(_RgRegGeralNatureza);

            return Updated(_RgRegGeralNatureza);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(RgRegGeralNatureza _RgRegGeralNatureza)
        {
            BO.EliminarRgRegGeralNatureza(_RgRegGeralNatureza);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(RgRegGeralNatureza _RgRegGeralNatureza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<RgRegGeralNatureza> _Delta = new Delta<RgRegGeralNatureza>();
            _Delta.CopyChangedValues(_RgRegGeralNatureza);

            _Delta.Patch(_RgRegGeralNatureza);
            return Updated(_RgRegGeralNatureza);
        }
    }
}
