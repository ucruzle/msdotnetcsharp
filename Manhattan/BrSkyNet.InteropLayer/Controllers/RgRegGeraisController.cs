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
    [ODataRoutePrefix("RgRegGerais")]
    public class RgRegGeraisController : ODataController
    {
        [Dependency]
        public RgRegGeralBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<RgRegGeral> _Result = BO.ListarRgRegGerais().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_empr={CodEmp}, cod_rg={CodRg})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] int CodEmp, [FromODataUri] int CodRg)
        {
            RgRegGeral _Result = null;
            _Result = BO.RecuperaRgRegGeral(CodEmp, CodRg);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(RgRegGeral _RgRegGeral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            BO.AdicionaRgRegGeal(_RgRegGeral);

            return Created(_RgRegGeral);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(RgRegGeral _RgRegGeral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlteraRgRegGeal(_RgRegGeral);

            return Updated(_RgRegGeral);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(RgRegGeral _RgRegGeral)
        {
            BO.EliminaRgRegGeal(_RgRegGeral);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(RgRegGeral _RgRegGeral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<RgRegGeral> _Delta = new Delta<RgRegGeral>();
            _Delta.CopyChangedValues(_RgRegGeral);

            _Delta.Patch(_RgRegGeral);
            return Updated(_RgRegGeral);
        }
    }
}
