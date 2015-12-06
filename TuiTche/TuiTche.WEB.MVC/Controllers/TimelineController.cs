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
        UsuarioRepositorio UsuarioRepositorio = new UsuarioRepositorio();
        HashtagRepositorio HashtagRepositorio = new HashtagRepositorio();
        CompartilharRepositorio CompartilharRepositorio = new CompartilharRepositorio();
        PublicacaoRepositorio PublicacaoRepositorio = new PublicacaoRepositorio();


        public int NumeroDeSeguidores()
        {
            Usuario usuario = UsuarioRepositorio.BuscarPorUsername(ControleDeSessao.UsuarioAtual.Username);
            return usuario.Seguidores.Count;
        }

        public int NumeroDeSeguindo()
        {
            Usuario usuario = UsuarioRepositorio.BuscarPorUsername(ControleDeSessao.UsuarioAtual.Username);
            return usuario.Seguindo.Count;
        }
        public JsonResult PalavrasMaisUtilizadas()
        {
            var palavras = HashtagRepositorio.PalavrasMaisUsadas();

            var json = palavras.Select(x => new { label = x.Palavra });

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Compartilhar(int IdPublicacao)
        {
            Compartilhar compartilhar = new Compartilhar();
            compartilhar.Publicacao = PublicacaoRepositorio.BuscarPorPorId(IdPublicacao);
            compartilhar.Usuario = UsuarioRepositorio.BuscarPorId(ControleDeSessao.UsuarioAtual.IdUsuario);
            compartilhar.DataCompartilhamento = DateTime.Now;
            CompartilharRepositorio.Compartilhar(compartilhar);
            Publicacao publicacao = compartilhar.Publicacao;
            publicacao.Compartilhar.Add(compartilhar);
            CompartilharRepositorio.AdicionarCompartilhamento(publicacao);
            //PublicacaoRepositorio.Criar(compartilhar.Publicacao);

            return View("../Publicacao/Index");
        }

    }
}