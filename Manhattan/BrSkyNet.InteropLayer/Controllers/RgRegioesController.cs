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
    [ODataRoutePrefix("RgRegioes")]
    public class RgRegioesController : ODataController
    {
        [Dependency]
        public RgRegiaoBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<RgRegiao> _Result = BO.ListarRgRegioes().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(sigla_regiao={SiglaRegiao})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] string SiglaRegiao)
        {
            RgRegiao _Result = BO.RecuperarRgRegiao(SiglaRegiao);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(RgRegiao _RgRegiao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarRgRegiao(_RgRegiao);

            return Created(_RgRegiao);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(RgRegiao _RgRegiao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarRgRegiao(_RgRegiao);

            return Updated(_RgRegiao);
        }

        [ODataRoute("(sigla_regiao={SiglaRegiao})")]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete([FromODataUri] string SiglaRegiao)
        {
            BO.EliminarRgRegiao(SiglaRegiao);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(RgRegiao _RgRegiao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<RgRegiao> _Delta = new Delta<RgRegiao>();
            _Delta.CopyChangedValues(_RgRegiao);

            _Delta.Patch(_RgRegiao);
            return Updated(_RgRegiao);
        }
    }
}
