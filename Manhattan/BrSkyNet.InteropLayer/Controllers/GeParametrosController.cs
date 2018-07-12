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
    [ODataRoutePrefix("GeParametros")]
    public class GeParametrosController : ODataController
    {
        [Dependency]
        public GeParametroBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<GeParametro> _Result = BO.ListarGeParametros().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(id_tabela={IdTabela})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] int IdTabela)
        {
            GeParametro _Result = BO.RecuperaGeGeParametro(IdTabela);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(GeParametro _GeParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarGeParametro(_GeParametro);

            return Created(_GeParametro);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(GeParametro _GeParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarGeParametro(_GeParametro);

            return Updated(_GeParametro);
        }

        [ODataRoute("(id_tabela={IdTabela})")]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete([FromODataUri] int IdTabela)
        {
            BO.EliminarGeParametro(IdTabela);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(GeParametro _GeParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<GeParametro> _Delta = new Delta<GeParametro>();
            _Delta.CopyChangedValues(_GeParametro);

            _Delta.Patch(_GeParametro);
            return Updated(_GeParametro);
        }
    }
}
