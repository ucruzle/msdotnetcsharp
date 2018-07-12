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
    [ODataRoutePrefix("RgFisicasJuridicas")]
    public class RgFisicasJuridicasController : ODataController
    {
        [Dependency]
        public RgFisicaJuridicaBO BO { get; set; }

        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        [ODataRoute]
        public IHttpActionResult Get()
        {
            IQueryable<RgFisicaJuridica> _Result = BO.ListarRgFisicasJuridicas().AsQueryable();
            return Ok(_Result);
        }

        [ODataRoute("(cod_empr={CodEmpr}, cod_rg={CodRg})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        [HttpGet]
        public IHttpActionResult Get([FromODataUri] int CodEmpr, [FromODataUri] int CodRg)
        {
            RgFisicaJuridica _Result = BO.RecuperarRgFisicaJuridica(CodEmpr, CodRg);
            return Ok(_Result);
        }

        //[ODataRoute("(cod_empr={CodEmpr}, cod_rg={CodRg}, num_cpf={NumCpf}, dig_cpf={DigCpf})")]
        //[EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        //[HttpGet]
        //public IHttpActionResult CPFJaExistente([FromODataUri] int CodEmpr, [FromODataUri] int CodRg, [FromODataUri] int NumCpf, [FromODataUri] int DigCpf)
        //{
        //    bool _Result = false;
        //    _Result = BO.CPFJaExistente(CodEmpr, CodRg, NumCpf, DigCpf);
        //    return Ok(_Result);
        //}

        //[ODataRoute("(cod_empr={CodEmpr}, cod_rg={CodRg}, cgc={Cgc}, dig_cgc={DigCgc})")]
        //[EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        //[HttpGet]
        //public IHttpActionResult CNPJJaExistente([FromODataUri] int CodEmpr, [FromODataUri] int CodRg, [FromODataUri] int Cgc, [FromODataUri] int DigCgc)
        //{
        //    bool _Result = false;
        //    _Result = BO.CNPJJaExistente(CodEmpr, CodRg, Cgc, DigCgc);
        //    return Ok(_Result);
        //}

        //[ODataRoute("(cod_empr={CodEmpr}, cod_rg={CodRg}, num_rg={NumRg}, dig_rg={DigRg})")]
        //[EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        //[HttpGet]
        //public IHttpActionResult RGJaExistente([FromODataUri] int CodEmpr, [FromODataUri] int CodRg, [FromODataUri] string NumRg, [FromODataUri] string DigRg)
        //{
        //    bool _Result = false;
        //    _Result = BO.RGJaExistente(CodEmpr, CodRg, NumRg, DigRg);
        //    return Ok(_Result);
        //}

        [ODataRoute()]
        [HttpPost]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Post(RgFisicaJuridica _RgFisicaJuridica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AdicionarRgFisicaJuridica(_RgFisicaJuridica);

            return Created(_RgFisicaJuridica);
        }

        [ODataRoute()]
        [HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Put(RgFisicaJuridica _RgFisicaJuridica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BO.AlterarRgFisicaJuridica(_RgFisicaJuridica);

            return Updated(_RgFisicaJuridica);
        }

        [ODataRoute()]
        [HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Delete(RgFisicaJuridica _RgFisicaJuridica)
        {
            BO.EliminarRgFisicaJuridica(_RgFisicaJuridica);
            return Content(HttpStatusCode.NoContent, "Deleted");
        }

        [ODataRoute()]
        [HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IHttpActionResult Patch(RgFisicaJuridica _RgFisicaJuridica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Delta<RgFisicaJuridica> _Delta = new Delta<RgFisicaJuridica>();
            _Delta.CopyChangedValues(_RgFisicaJuridica);

            _Delta.Patch(_RgFisicaJuridica);
            return Updated(_RgFisicaJuridica);
        }
    }
}
