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
    [ODataRoutePrefix("CtNiveisSeis")]
    public class CtNiveisSeisController : ODataController
    {
        [Dependency]
        public CtNivelSeisBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<CtNivelSeis> _Result = BO.ListarCtNiveisSeis().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_empr={CodEmpr}, cod_plano_cont={CodPlanoCont}, cod_nivel1={CodNivel1}, cod_nivel2={CodNivel2}, cod_nivel3={CodNivel3}, cod_nivel4={CodNivel4}, cod_nivel5={CodNivel5}, cod_nivel6={CodNivel6})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get(int CodEmpr, int CodPlanoCont, int CodNivel1, int CodNivel2, int CodNivel3, int CodNivel4, int CodNivel5, int CodNivel6)
        {
            CtNivelSeis _Result = BO.RecuperarCtNivelSeis(CodEmpr, CodPlanoCont, CodNivel1, CodNivel2, CodNivel3, CodNivel4, CodNivel5, CodNivel6);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(CtNivelSeis _CtNivelSeis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarCtNivelSeis(_CtNivelSeis);

            return Created(_CtNivelSeis);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(CtNivelSeis _CtNivelSeis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarCtNivelSeis(_CtNivelSeis);

            return Updated(_CtNivelSeis);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(CtNivelSeis _CtNivelSeis)
        {
            BO.EliminarCtNivelSeis(_CtNivelSeis);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(CtNivelSeis _CtNivelSeis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<CtNivelSeis> _Delta = new Delta<CtNivelSeis>();
            _Delta.CopyChangedValues(_CtNivelSeis);

            _Delta.Patch(_CtNivelSeis);
            return Updated(_CtNivelSeis);
        }
    }
}
