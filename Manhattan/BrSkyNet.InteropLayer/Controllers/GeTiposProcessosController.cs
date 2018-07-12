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
    [ODataRoutePrefix("GeTiposProcessos")]
    public class GeTiposProcessosController : ODataController
    {
        [Dependency]
        public GeTipoProcessoBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<GeTipoProcesso> _Result = BO.ListarGeTiposProcessos().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_tipo_proc={CodTipoProc})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] int CodTipoProc)
        {
            GeTipoProcesso _Result = BO.RecuperaGeTipoProcesso(CodTipoProc);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(GeTipoProcesso _GeTipoProcesso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarGeTipoProcesso(_GeTipoProcesso);

            return Created(_GeTipoProcesso);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(GeTipoProcesso _GeTipoProcesso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarGeTipoProcesso(_GeTipoProcesso);

            return Updated(_GeTipoProcesso);
        }

        [ODataRoute("(cod_tipo_proc={CodTipoProc})")]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete([FromODataUri] int CodTipoProc)
        {
            BO.EliminarGeTipoProcesso(CodTipoProc);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(GeTipoProcesso _GeTipoProcesso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<GeTipoProcesso> _Delta = new Delta<GeTipoProcesso>();
            _Delta.CopyChangedValues(_GeTipoProcesso);

            _Delta.Patch(_GeTipoProcesso);
            return Updated(_GeTipoProcesso);
        }
    }
}
