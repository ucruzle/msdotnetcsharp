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
    [ODataRoutePrefix("CtNiveisUm")]
    public class CtNiveisUmController : ODataController
    {
        [Dependency]
        public CtNivelUmBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<CtNivelUm> _Result = BO.ListarCtNiveisUm().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_empr={CodEmpr}, cod_plano_cont={CodPlanoCont}, cod_nivel1={CodNivel1})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get(int CodEmpr, int CodPlanoCont, int CodNivel1)
        {
            CtNivelUm _Result = BO.RecuperarCtNivelUm(CodEmpr, CodPlanoCont, CodNivel1);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(CtNivelUm _CtNivelUm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarCtNivelUm(_CtNivelUm);

            return Created(_CtNivelUm);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(CtNivelUm _CtNivelUm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarCtNivelUm(_CtNivelUm);

            return Updated(_CtNivelUm);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(CtNivelUm _CtNivelUm)
        {
            BO.EliminarCtNivelUm(_CtNivelUm);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(CtNivelUm _CtNivelUm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<CtNivelUm> _Delta = new Delta<CtNivelUm>();
            _Delta.CopyChangedValues(_CtNivelUm);

            _Delta.Patch(_CtNivelUm);
            return Updated(_CtNivelUm);
        }
    }
}
