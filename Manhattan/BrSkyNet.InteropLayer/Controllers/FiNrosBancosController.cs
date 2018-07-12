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
    [ODataRoutePrefix("FiNrosBancos")]
    public class FiNrosBancosController : ODataController
    {
        [Dependency]
        public FiNroBancoBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<FiNroBanco> _Result = BO.ListarFiNrosBancos().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(nro_banco={NroBanco})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get(int NroBanco)
        {
            FiNroBanco _Result = BO.RecuperarFiNroBanco(NroBanco);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(FiNroBanco _FiNroBanco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarFiNroBanco(_FiNroBanco);

            return Created(_FiNroBanco);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(FiNroBanco _FiNroBanco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarFiNroBanco(_FiNroBanco);

            return Updated(_FiNroBanco);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(FiNroBanco _FiNroBanco)
        {
            BO.EliminarFiNroBanco(_FiNroBanco);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(FiNroBanco _FiNroBanco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<FiNroBanco> _Delta = new Delta<FiNroBanco>();
            _Delta.CopyChangedValues(_FiNroBanco);

            _Delta.Patch(_FiNroBanco);
            return Updated(_FiNroBanco);
        }
    }
}
