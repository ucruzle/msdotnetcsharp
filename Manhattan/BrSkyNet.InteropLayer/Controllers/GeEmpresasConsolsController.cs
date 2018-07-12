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
    [ODataRoutePrefix("GeEmpresasConsols")]
    public class GeEmpresasConsolsController : ODataController
    {
        [Dependency]
        public GeEmpresaConsolBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<GeEmpresaConsol> _Result = BO.ListarGeEmpresasConsols().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_empr_consol={CodEmprConsol})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get(int CodEmprConsol)
        {
            GeEmpresaConsol _Result = BO.RecuperaGeEmpresaConsol(CodEmprConsol);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(GeEmpresaConsol _GeEmpresaConsol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarGeEmpresaConsol(_GeEmpresaConsol);

            return Created(_GeEmpresaConsol);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(GeEmpresaConsol _GeEmpresaConsol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarGeEmpresaConsol(_GeEmpresaConsol);

            return Updated(_GeEmpresaConsol);
        }

        [ODataRoute("(cod_empr_consol={CodEmprConsol})")]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(int CodEmprConsol)
        {
            BO.EliminarGeEmpresaConsol(CodEmprConsol);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(GeEmpresaConsol _GeEmpresaConsol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<GeEmpresaConsol> _Delta = new Delta<GeEmpresaConsol>();
            _Delta.CopyChangedValues(_GeEmpresaConsol);

            _Delta.Patch(_GeEmpresaConsol);
            return Updated(_GeEmpresaConsol);
        }
    }
}
