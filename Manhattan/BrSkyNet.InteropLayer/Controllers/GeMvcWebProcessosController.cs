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
    [ODataRoutePrefix("GeMvcWebProcessos")]
    public class GeMvcWebProcessosController : ODataController
    {
        [Dependency]
        public GeMvcWebProcessoBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<GeMvcWebProcesso> _Result = BO.ListarGeMvcWebProcessos().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_proc={CodProc})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] int CodProc)
        {
            GeMvcWebProcesso _Result = BO.RecuperaGeMvcWebProcesso(CodProc);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(GeMvcWebProcesso _GeMvcWebProcesso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarGeMvcWebProcesso(_GeMvcWebProcesso);

            return Created(_GeMvcWebProcesso);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(GeMvcWebProcesso _GeMvcWebProcesso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarGeMvcWebProcesso(_GeMvcWebProcesso);

            return Updated(_GeMvcWebProcesso);
        }

        [ODataRoute("(cod_proc={CodProc})")]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete([FromODataUri] int CodProc)
        {
            BO.EliminarGeMvcWebProcesso(CodProc);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(GeMvcWebProcesso _GeMvcWebProcesso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<GeMvcWebProcesso> _Delta = new Delta<GeMvcWebProcesso>();
            _Delta.CopyChangedValues(_GeMvcWebProcesso);

            _Delta.Patch(_GeMvcWebProcesso);
            return Updated(_GeMvcWebProcesso);
        }
    }
}
