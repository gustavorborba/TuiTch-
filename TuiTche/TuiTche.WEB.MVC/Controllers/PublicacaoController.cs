using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuiTche.Dominio;
using TuiTche.Repositorio.EF;
using TuiTche.WEB.MVC.Models;
using TwiTche.Repositorio.EF;

namespace TuiTche.WEB.MVC.Controllers
{
    public class PublicacaoController : Controller
    {
        // GET: Publicacao
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Publicar(PublicarModel publicar)
        {
            var usuarioRepositorio = new UsuarioRepositorio();
            var publicacaoRepositorio = new PublicacaoRepositorio();

            publicacaoRepositorio.Criar(new Publicacao()
            {
                Descricao = publicar.Conteudo,
                DataPublicacao = DateTime.Now,
                Usuario = usuarioRepositorio.BuscarPorUsername(ControleDeSessao.UsuarioLogado.Username)
        });
        }
        }
    }
}