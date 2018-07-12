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
    [ODataRoutePrefix("FiTiposCtasBancos")]
    public class FiTiposCtasBancosController : ODataController
    {
        [Dependency]
        public FiTipoCtaBancoBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<FiTipoCtaBanco> _Result = BO.ListarFiTiposCtasBancos().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_tipo_cta={CodTipoCta})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get(int CodTipoCta)
        {
            FiTipoCtaBanco _Result = BO.RecuperarFiTipoCtaBanco(CodTipoCta);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(FiTipoCtaBanco _FiTipoCtaBanco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarFiTipoCtaBanco(_FiTipoCtaBanco);

            return Created(_FiTipoCtaBanco);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(FiTipoCtaBanco _FiTipoCtaBanco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarFiTipoCtaBanco(_FiTipoCtaBanco);

            return Updated(_FiTipoCtaBanco);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(FiTipoCtaBanco _FiTipoCtaBanco)
        {
            BO.EliminarFiTipoCtaBanco(_FiTipoCtaBanco);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(FiTipoCtaBanco _FiTipoCtaBanco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<FiTipoCtaBanco> _Delta = new Delta<FiTipoCtaBanco>();
            _Delta.CopyChangedValues(_FiTipoCtaBanco);

            _Delta.Patch(_FiTipoCtaBanco);
            return Updated(_FiTipoCtaBanco);
        }
    }
}
