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
    [ODataRoutePrefix("RgParamRegsGerais")]
    public class RgParamRegsGeraisController : ODataController
    {
        [Dependency]
        public RgParamRegGeralBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<RgParamRegGeral> _Result = BO.ListarRgParamRegsGerais().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_empr={CodEmpr})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] int CodEmpr)
        {
            RgParamRegGeral _Result = BO.RecuperaRgParamRegGeral(CodEmpr);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(RgParamRegGeral _RgParamRegGeral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarRgParamRegGeral(_RgParamRegGeral);

            return Created(_RgParamRegGeral);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(RgParamRegGeral _RgParamRegGeral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarRgParamRegGeral(_RgParamRegGeral);

            return Updated(_RgParamRegGeral);
        }

        [ODataRoute("(cod_empr={CodEmpr})")]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(int CodEmpr)
        {
            BO.EliminarRgParamRegGeral(CodEmpr);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(RgParamRegGeral _RgParamRegGeral)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<RgParamRegGeral> _Delta = new Delta<RgParamRegGeral>();
            _Delta.CopyChangedValues(_RgParamRegGeral);

            _Delta.Patch(_RgParamRegGeral);
            return Updated(_RgParamRegGeral);
        }
    }
}
