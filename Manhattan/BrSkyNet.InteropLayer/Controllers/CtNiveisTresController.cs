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
    [ODataRoutePrefix("CtNiveisTres")]
    public class CtNiveisTresController : ODataController
    {
        [Dependency]
        public CtNivelTresBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<CtNivelTres> _Result = BO.ListarCtNiveisTres().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_empr={CodEmpr}, cod_plano_cont={CodPlanoCont}, cod_nivel1={CodNivel1}, cod_nivel2={CodNivel2}, cod_nivel3={CodNivel3})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get(int CodEmpr, int CodPlanoCont, int CodNivel1, int CodNivel2, int CodNivel3)
        {
            CtNivelTres _Result = BO.RecuperarCtNivelTres(CodEmpr, CodPlanoCont, CodNivel1, CodNivel2, CodNivel3);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(CtNivelTres _CtNivelTres)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarCtNivelTres(_CtNivelTres);

            return Created(_CtNivelTres);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(CtNivelTres _CtNivelTres)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarCtNivelTres(_CtNivelTres);

            return Updated(_CtNivelTres);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(CtNivelTres _CtNivelTres)
        {
            BO.EliminarCtNivelTres(_CtNivelTres);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(CtNivelTres _CtNivelTres)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<CtNivelTres> _Delta = new Delta<CtNivelTres>();
            _Delta.CopyChangedValues(_CtNivelTres);

            _Delta.Patch(_CtNivelTres);
            return Updated(_CtNivelTres);
        }
    }
}
