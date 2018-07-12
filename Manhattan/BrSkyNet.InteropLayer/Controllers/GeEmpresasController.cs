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
    [ODataRoutePrefix("GeEmpresas")]
    public class GeEmpresasController : ODataController
    {
        [Dependency]
        public GeEmpresaBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<GeEmpresa> _Result = BO.ListarGeEmpresas().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_empr={CodEmp})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] int CodEmp)
        {
            GeEmpresa _Result = BO.RecuperaEmpresa(CodEmp);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(GeEmpresa _GeEmpresa) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarEmpresa(_GeEmpresa);

            return Created(_GeEmpresa);
        }

        [ODataRoute("({CodEmp})")]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put([FromODataUri] int CodEmp, GeEmpresa _GeEmpresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (CodEmp != _GeEmpresa.cod_empr)
            {
                return BadRequest();
            }

            BO.AlterarEmpresa(_GeEmpresa);

            return Updated(_GeEmpresa);
        }

        [ODataRoute("({CodEmp})")]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete([FromODataUri] int CodEmp)
        {
            BO.EliminarEmpresa(CodEmp);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute("({CodEmp})")]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch([FromODataUri] int CodEmp, Delta<GeEmpresa> _Delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            GeEmpresa _GeEmpresa = BO.RecuperaEmpresa(CodEmp);
            _Delta.Patch(_GeEmpresa);
            return Updated(_GeEmpresa);
        }
    }
}
