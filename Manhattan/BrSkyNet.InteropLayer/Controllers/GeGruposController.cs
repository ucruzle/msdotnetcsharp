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
    [ODataRoutePrefix("GeGrupos")]
    public class GeGruposController : ODataController
    {
        [Dependency]
        public GeGrupoBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<GeGrupo> _Result = BO.ListarGeGrupos().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_grupo={CodGrupo})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] int CodGrupo)
        {
            GeGrupo _Result = BO.RecuperaGeGrupo(CodGrupo);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(GeGrupo _GeGrupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarGeGrupo(_GeGrupo);

            return Created(_GeGrupo);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(GeGrupo _GeGrupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarGeGrupo(_GeGrupo);

            return Updated(_GeGrupo);
        }

        [ODataRoute("(cod_grupo={CodGrupo})")]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete([FromODataUri] int CodGrupo)
        {
            BO.EliminarGeGrupo(CodGrupo);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(GeGrupo _GeGrupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<GeGrupo> _Delta = new Delta<GeGrupo>();
            _Delta.CopyChangedValues(_GeGrupo);

            _Delta.Patch(_GeGrupo);
            return Updated(_GeGrupo);
        }
    }
}
