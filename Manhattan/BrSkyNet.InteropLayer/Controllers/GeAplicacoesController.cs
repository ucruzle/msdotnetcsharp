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
    [ODataRoutePrefix("GeAplicacoes")]
    public class GeAplicacoesController : ODataController
    {
        [Dependency]
        public GeAplicacaoBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<GeAplicacao> _Result = BO.ListarGeAplicacoes().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_aplic={CodAplic})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get(int CodAplic)
        {
            GeAplicacao _Result = BO.RecuperarGeAplicacao(CodAplic);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(GeAplicacao _GeAplicacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarGeAplicacao(_GeAplicacao);

            return Created(_GeAplicacao);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(GeAplicacao _GeAplicacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarGeAplicacao(_GeAplicacao);

            return Updated(_GeAplicacao);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(GeAplicacao _GeAplicacao)
        {
            BO.EliminarGeAplicacao(_GeAplicacao);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(GeAplicacao _GeAplicacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<GeAplicacao> _Delta = new Delta<GeAplicacao>();
            _Delta.CopyChangedValues(_GeAplicacao);

            _Delta.Patch(_GeAplicacao);
            return Updated(_GeAplicacao);
        }
    }
}
