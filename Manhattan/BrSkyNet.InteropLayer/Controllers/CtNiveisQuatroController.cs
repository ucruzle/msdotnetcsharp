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
    [ODataRoutePrefix("CtNiveisQuatro")]
    public class CtNiveisQuatroController : ODataController
    {
        [Dependency]
        public CtNivelQuatroBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<CtNivelQuatro> _Result = BO.ListarCtNiveisQuatro().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_empr={CodEmpr}, cod_plano_cont={CodPlanoCont}, cod_nivel1={CodNivel1}, cod_nivel2={CodNivel2}, cod_nivel3={CodNivel3}, cod_nivel4={CodNivel4})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get(int CodEmpr, int CodPlanoCont, int CodNivel1, int CodNivel2, int CodNivel3, int CodNivel4)
        {
            CtNivelQuatro _Result = BO.RecuperarCtNivelQuatro(CodEmpr, CodPlanoCont, CodNivel1, CodNivel2, CodNivel3, CodNivel4);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(CtNivelQuatro _CtNivelQuatro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarCtNivelQuatro(_CtNivelQuatro);

            return Created(_CtNivelQuatro);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(CtNivelQuatro _CtNivelQuatro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarCtNivelQuatro(_CtNivelQuatro);

            return Updated(_CtNivelQuatro);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(CtNivelQuatro _CtNivelQuatro)
        {
            BO.EliminarCtNivelQuatro(_CtNivelQuatro);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(CtNivelQuatro _CtNivelQuatro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<CtNivelQuatro> _Delta = new Delta<CtNivelQuatro>();
            _Delta.CopyChangedValues(_CtNivelQuatro);

            _Delta.Patch(_CtNivelQuatro);
            return Updated(_CtNivelQuatro);
        }
    }
}
