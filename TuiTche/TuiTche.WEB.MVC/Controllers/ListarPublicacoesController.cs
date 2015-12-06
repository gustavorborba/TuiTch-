using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuiTche.Repositorio.EF;
using TuiTche.WEB.MVC.Models;
using TuiTche.WEB.MVC.Seguranca;

namespace TuiTche.WEB.MVC.Controllers
{
    public class ListarPublicacoesController : Controller
    {
        PublicacaoRepositorio publicacaoRepositorio = new PublicacaoRepositorio();
        // GET: Listar
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult _ListarPublicacoes(ListaDePublicacaoModel model)
        {
            if (model.ListaPublicacoes.Count == 0)
            {
                int usuarioAtual = ControleDeSessao.UsuarioAtual.IdUsuario;
                var listaDePublicacoes = publicacaoRepositorio.GerarTimeLine(usuarioAtual, 0);
                foreach (var publicacao in listaDePublicacoes)
                {
                    model.ListaPublicacoes.Add(new PublicacaoModel(publicacao));
                }
            }
            return PartialView("_ListarPublicacoes", model);
        }

        [HttpPost]
        public ActionResult getData(int next)
        {
            int usuarioAtual = ControleDeSessao.UsuarioAtual.IdUsuario;
            var listaDePublicacoes = publicacaoRepositorio.GerarTimeLine(usuarioAtual, next);
            var model = new ListaDePublicacaoModel();
            foreach (var publicacao in listaDePublicacoes)
            {
                model.ListaPublicacoes.Add(new PublicacaoModel(publicacao));
            }
            ScrollModel scro = new ScrollModel();
            scro.HTMLString = RenderPartialViewToString("_ListarPublicacoes", model);
            return Json(scro);
        }

        private string RenderPartialViewToString(string viewName, object model)

        {
            if (string.IsNullOrEmpty(viewName))

                viewName = ControllerContext.RouteData.GetRequiredString("action");
            ViewData.Model = model;
            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }

        }
    }
}