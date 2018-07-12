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
    [ODataRoutePrefix("RgEnderecos")]
    public class RgEnderecosController : ODataController
    {
        [Dependency]
        public RgEnderecoBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<RgEndereco> _Result = BO.ListarRgEnderecos().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_empr={CodEmpr}, cod_rg={CodRg})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] int CodEmpr,[FromODataUri] int CodRg)
        {
            RgEndereco _Result = BO.RecuperaRgEndereco(CodEmpr, CodRg);
            return Ok(_Result);
        }

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(RgEndereco _RgEndereco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarRgEndereco(_RgEndereco);

            return Created(_RgEndereco);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(RgEndereco _RgEndereco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarRgEndereco(_RgEndereco);

            return Updated(_RgEndereco);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(RgEndereco _RgEndereco)
        {
            BO.EliminarRgEndereco(_RgEndereco);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(RgEndereco _RgEndereco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<RgEndereco> _Delta = new Delta<RgEndereco>();
            _Delta.CopyChangedValues(_RgEndereco);

            _Delta.Patch(_RgEndereco);
            return Updated(_RgEndereco);
        }
    }
}
