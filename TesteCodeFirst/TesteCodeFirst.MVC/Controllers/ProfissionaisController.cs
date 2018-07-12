using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using TesteCodeFirst.BLL;
using TesteCodeFirst.Entities;

namespace TesteCodeFirst.MVC.Controllers
{
    public class ProfissionaisController : Controller
    {
        [Dependency]
        public ProfissionalBO Profissional_BO { get; set; }

        [Dependency]
        public OcupacaoBO Ocupacao_BO { get; set; }

        [HttpGet]
        public ActionResult Index()
        {
            return View(Profissional_BO.ListarResumoProfissionais());
        }

        private ActionResult ProcessarGravacaoDadosProfissional(
            Profissional profissional, bool inclusao)
        {
            string CampoInconsistente = null;
            string DescricaoInconsistencia = null;

            if (ModelState.IsValid && !Profissional_BO
                    .ValidarDadosProfissional(profissional,
                        out CampoInconsistente,
                        out DescricaoInconsistencia))
            {
                ModelState.AddModelError(CampoInconsistente,
                    DescricaoInconsistencia);
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Ocupacoes = Ocupacao_BO.ListarOcupacoes();
                return View(profissional);
            }

            if (inclusao)
                Profissional_BO.IncluirDadosProfissional(profissional);
            else
                Profissional_BO.AtualizarDadosProfissional(profissional);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Inserir()
        {
            var ocupacoes = Ocupacao_BO
                .ListarOcupacoes().ToList();
            ocupacoes.Insert(0,
                new Ocupacao()
                {
                    Id = null,
                    NomeOcupacao = "Selecione uma Ocupação..."
                });
            ViewBag.Ocupacoes = ocupacoes;
            return View(new Profissional());
        }

        [HttpPost]
        public ActionResult Inserir(Profissional profissional)
        {
            return ProcessarGravacaoDadosProfissional(
                profissional, true);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            Profissional profissional =
                Profissional_BO.ObterDadosProfissional(id);
            ViewBag.Ocupacoes = Ocupacao_BO.ListarOcupacoes();
            return View(profissional);
        }

        [HttpPost]
        public ActionResult Editar(Profissional profissional)
        {
            return ProcessarGravacaoDadosProfissional(
                profissional, false);
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            Profissional profissional =
                Profissional_BO.ObterDadosProfissional(id);
            return View(profissional);
        }

        [HttpPost]
        public ActionResult Excluir(Profissional profissional)
        {
            Profissional_BO.ExcluirProfissional(
                profissional.Id.Value);
            return RedirectToAction("Index");
        }
	}
}