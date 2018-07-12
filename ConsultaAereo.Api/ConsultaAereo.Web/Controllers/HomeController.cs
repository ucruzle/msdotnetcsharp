using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsultaAereo.Web.Controllers
{
    public class HomeController : Controller
    {
        private ConsultaAereoProxy.Container _servicoOData;

        public HomeController()
        {
            var uri = new Uri("http://localhost:2178/odata");
            _servicoOData = new ConsultaAereoProxy.Container(uri);
        }

        public ActionResult Index()
        {
            var passagens =
                from passagem in this._servicoOData.PassagemAerea
                orderby passagem.DataIda
                select passagem;

            var novaPassagem = new ConsultaAereoProxy.PassagemAerea();
            novaPassagem.DataIda = new DateTime(2014, 10, 10);
            novaPassagem.DataVolta = new DateTime(2014, 10, 25);
            novaPassagem.Origem = new ConsultaAereoProxy.Aeroporto()
            {
                NomeCompleto = "Aeroporto Internacional de Miami",
                Sigla = "MIA"
            };
            novaPassagem.Destino = new ConsultaAereoProxy.Aeroporto()
            {
                NomeCompleto = "Aeroporto Internacional de Guarulhos",
                Sigla = "GRU"
            };
            novaPassagem.QuantidadePax = 3;

            this._servicoOData.AddToPassagemAerea(novaPassagem);

            novaPassagem.QuantidadePax = 1;

            this._servicoOData.UpdateObject(novaPassagem);

            this._servicoOData.DeleteObject(novaPassagem);

            this._servicoOData.SaveChanges();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}