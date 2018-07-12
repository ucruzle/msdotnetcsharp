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
    [ODataRoutePrefix("CtNiveisCinco")]
    public class CtNiveisCincoController : ODataController
    {
        [Dependency]
        public CtNivelCincoBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<CtNivelCinco> _Result = BO.ListarCtNiveisCinco().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_empr={CodEmpr}, cod_plano_cont={CodPlanoCont}, cod_nivel1={CodNivel1}, cod_nivel2={CodNivel2}, cod_nivel3={CodNivel3}, cod_nivel4={CodNivel4}, cod_nivel5={CodNivel5})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get(int CodEmpr, int CodPlanoCont, int CodNivel1, int CodNivel2, int CodNivel3, int CodNivel4, int CodNivel5)
        {
            CtNivelCinco _Result = BO.RecuperarCtNivelCinco(CodEmpr, CodPlanoCont, CodNivel1, CodNivel2, CodNivel3, CodNivel4, CodNivel5);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(CtNivelCinco _CtNivelCinco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarCtNivelCinco(_CtNivelCinco);

            return Created(_CtNivelCinco);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(CtNivelCinco _CtNivelCinco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarCtNivelCinco(_CtNivelCinco);

            return Updated(_CtNivelCinco);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(CtNivelCinco _CtNivelCinco)
        {
            BO.EliminarCtNivelCinco(_CtNivelCinco);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(CtNivelCinco _CtNivelCinco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<CtNivelCinco> _Delta = new Delta<CtNivelCinco>();
            _Delta.CopyChangedValues(_CtNivelCinco);

            _Delta.Patch(_CtNivelCinco);
            return Updated(_CtNivelCinco);
        }
    }
}
