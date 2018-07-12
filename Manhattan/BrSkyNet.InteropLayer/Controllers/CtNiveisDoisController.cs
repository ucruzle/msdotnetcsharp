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
    [ODataRoutePrefix("CtNiveisDois")]
    public class CtNiveisDoisController : ODataController
    {
        [Dependency]
        public CtNivelDoisBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<CtNivelDois> _Result = BO.ListarCtNiveisDois().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_empr={CodEmpr}, cod_plano_cont={CodPlanoCont}, cod_nivel1={CodNivel1}, cod_nivel2={CodNivel2})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get(int CodEmpr, int CodPlanoCont, int CodNivel1, int CodNivel2)
        {
            CtNivelDois _Result = BO.RecuperarCtNivelDois(CodEmpr, CodPlanoCont, CodNivel1, CodNivel2);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(CtNivelDois _CtNivelDois)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarCtNivelDois(_CtNivelDois);

            return Created(_CtNivelDois);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(CtNivelDois _CtNivelDois)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarCtNivelDois(_CtNivelDois);

            return Updated(_CtNivelDois);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(CtNivelDois _CtNivelDois)
        {
            BO.EliminarCtNivelDois(_CtNivelDois);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(CtNivelDois _CtNivelDois)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<CtNivelDois> _Delta = new Delta<CtNivelDois>();
            _Delta.CopyChangedValues(_CtNivelDois);

            _Delta.Patch(_CtNivelDois);
            return Updated(_CtNivelDois);
        }
    }
}
