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
    public class TimelineController : Controller
    {
        UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
        HashtagRepositorio hashtagRepositorio = new HashtagRepositorio();


        public int NumeroDeSeguidores()
        {
            Usuario usuario = usuarioRepositorio.BuscarPorUsername(ControleDeSessao.UsuarioAtual.Username);
            return usuario.Seguidores.Count;
        }

        public int NumeroDeSeguindo()
        {
            Usuario usuario = usuarioRepositorio.BuscarPorUsername(ControleDeSessao.UsuarioAtual.Username);
            return usuario.Seguindo.Count;
        }
        public JsonResult PalavrasMaisUtilizadas()
        {
            var palavras = hashtagRepositorio.PalavrasMaisUsadas();

            var json = palavras.Select(x => new { label = x.Palavra });

            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}