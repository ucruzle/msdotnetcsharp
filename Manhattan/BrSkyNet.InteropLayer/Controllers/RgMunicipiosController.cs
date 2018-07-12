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
    [ODataRoutePrefix("RgMunicipios")]
    public class RgMunicipiosController : ODataController
    {
        [Dependency]
        public RgMunicipioBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<RgMunicipio> _Result = BO.ListarRgMunicipios().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_municipio={CodMunicipio})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] int CodMunicipio)
        {
            RgMunicipio _Result = BO.RecuperarRgMunicipio(CodMunicipio);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(RgMunicipio _RgMunicipio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarRgMunicipio(_RgMunicipio);

            return Created(_RgMunicipio);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(RgMunicipio _RgMunicipio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarRgMunicipio(_RgMunicipio);

            return Updated(_RgMunicipio);
        }

        [ODataRoute("(cod_municipio={CodMunicipio})")]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(int CodMunicipio)
        {
            BO.EliminarRgEstado(CodMunicipio);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(RgMunicipio _RgMunicipio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<RgMunicipio> _Delta = new Delta<RgMunicipio>();
            _Delta.CopyChangedValues(_RgMunicipio);

            _Delta.Patch(_RgMunicipio);
            return Updated(_RgMunicipio);
        }
    }
}
