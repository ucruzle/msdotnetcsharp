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
    [ODataRoutePrefix("CtPlanosContabeis")]
    public class CtPlanosContabeisController : ODataController
    {
        [Dependency]
        public CtPlanoContabilBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<CtPlanoContabil> _Result = BO.ListarCtPlanosContabeis().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_plano_cont={CodPlanoCont})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get(int CodPlanoCont)
        {
            CtPlanoContabil _Result = BO.RecuperarCtPlanoContabil(CodPlanoCont);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(CtPlanoContabil _CtPlanoContabil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarCtPlanoContabil(_CtPlanoContabil);

            return Created(_CtPlanoContabil);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(CtPlanoContabil _CtPlanoContabil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarCtPlanoContabil(_CtPlanoContabil);

            return Updated(_CtPlanoContabil);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(CtPlanoContabil _CtPlanoContabil)
        {
            BO.EliminarCtPlanoContabil(_CtPlanoContabil);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(CtPlanoContabil _CtPlanoContabil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<CtPlanoContabil> _Delta = new Delta<CtPlanoContabil>();
            _Delta.CopyChangedValues(_CtPlanoContabil);

            _Delta.Patch(_CtPlanoContabil);
            return Updated(_CtPlanoContabil);
        }
    }
}
