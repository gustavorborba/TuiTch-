using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuiTche.Dominio;
using TuiTche.Repositorio.EF;
using TuiTche.WEB.MVC.Seguranca;

namespace TuiTche.WEB.MVC.Controllers
{
    [Authorize]
    public class TimelineController : Controller
    {
        UsuarioRepositorio UsuarioRepositorio = new UsuarioRepositorio();
        HashtagRepositorio HashtagRepositorio = new HashtagRepositorio();
        CompartilharRepositorio CompartilharRepositorio = new CompartilharRepositorio();
        PublicacaoRepositorio PublicacaoRepositorio = new PublicacaoRepositorio();

        public JsonResult PalavrasMaisUtilizadas()
        {
            var palavras = HashtagRepositorio.PalavrasMaisUsadas();

            var json = palavras.Select(x => new { label = x.Palavra });

            return Json(json, JsonRequestBehavior.AllowGet);
        }

    }
}