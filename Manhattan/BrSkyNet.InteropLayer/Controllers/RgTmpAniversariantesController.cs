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
    [ODataRoutePrefix("RgTmpAniversariantes")]
    public class RgTmpAniversariantesController : ODataController
    {
        [Dependency]
        public RgTmpAniversarianteBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<RgTmpAniversariante> _Result = BO.ListarRgTmpAniversariantes().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(usuario={Usuario}, cod_rg={CodRg})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] string Usuario, [FromODataUri] int CodRg)
        {
            RgTmpAniversariante _Result = BO.RecuperarRgTmpAniversariante(Usuario, CodRg);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(RgTmpAniversariante _RgTmpAniversariante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarRgTmpAniversariante(_RgTmpAniversariante);

            return Created(_RgTmpAniversariante);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(RgTmpAniversariante _RgTmpAniversariante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarRgTmpAniversariante(_RgTmpAniversariante);

            return Updated(_RgTmpAniversariante);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(RgTmpAniversariante _RgTmpAniversariante)
        {
            BO.EliminarRgTmpAniversariante(_RgTmpAniversariante);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(RgTmpAniversariante _RgTmpAniversariante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<RgTmpAniversariante> _Delta = new Delta<RgTmpAniversariante>();
            _Delta.CopyChangedValues(_RgTmpAniversariante);

            _Delta.Patch(_RgTmpAniversariante);
            return Updated(_RgTmpAniversariante);
        }
    }
}
