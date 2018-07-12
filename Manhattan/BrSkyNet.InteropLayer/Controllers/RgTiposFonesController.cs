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
    [ODataRoutePrefix("RgTiposFones")]
    public class RgTiposFonesController : ODataController
    {
        [Dependency]
        public RgTipoFoneBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<RgTipoFone> _Result = BO.ListarRgTiposFones().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_tipo_fone={CodTipoFone})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] int CodTipoFone)
        {
            RgTipoFone _Result = BO.RecuperarRgTipoFone(CodTipoFone);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(RgTipoFone _RgTipoFone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarRgTipoFone(_RgTipoFone);

            return Created(_RgTipoFone);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(RgTipoFone _RgTipoFone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarRgTipoFone(_RgTipoFone);

            return Updated(_RgTipoFone);
        }

        [ODataRoute("(cod_tipo_fone={CodTipoFone})")]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete([FromODataUri] int CodTipoFone)
        {
            BO.EliminarRgTipoFone(CodTipoFone);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(RgTipoFone _RgTipoFone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<RgTipoFone> _Delta = new Delta<RgTipoFone>();
            _Delta.CopyChangedValues(_RgTipoFone);

            _Delta.Patch(_RgTipoFone);
            return Updated(_RgTipoFone);
        }
    }
}
