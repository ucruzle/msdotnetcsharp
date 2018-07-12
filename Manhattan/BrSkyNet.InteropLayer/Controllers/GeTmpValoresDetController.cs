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
    [ODataRoutePrefix("GeTmpValoresDet")]
    public class GeTmpValoresDetController : ODataController
    {
        [Dependency]
        public GeTmpValorDetBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<GeTmpValorDet> _Result = BO.ListarGeTmpValoresDet().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(usuario={Usuario}, codigo={Codigo})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] string Usuario, [FromODataUri] int Codigo)
        {
            GeTmpValorDet _Result = BO.RecuperaGeTmpValorDet(Usuario, Codigo);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(GeTmpValorDet _GeTmpValorDet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarGeTmpValorDet(_GeTmpValorDet);

            return Created(_GeTmpValorDet);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(GeTmpValorDet _GeTmpValorDet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarGeTmpValorDet(_GeTmpValorDet);

            return Updated(_GeTmpValorDet);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(GeTmpValorDet _GeTmpValorDet)
        {
            BO.EliminarGeTmpValorDet(_GeTmpValorDet);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(GeTmpValorDet _GeTmpValorDet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<GeTmpValorDet> _Delta = new Delta<GeTmpValorDet>();
            _Delta.CopyChangedValues(_GeTmpValorDet);

            _Delta.Patch(_GeTmpValorDet);
            return Updated(_GeTmpValorDet);
        }
    }
}
