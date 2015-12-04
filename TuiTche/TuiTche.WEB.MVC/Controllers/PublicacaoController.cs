using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuiTche.Dominio;
using TuiTche.Repositorio.EF;
using TuiTche.WEB.MVC.Models;
using TuiTche.WEB.MVC.Seguranca;
using TwiTche.Repositorio.EF;

namespace TuiTche.WEB.MVC.Controllers
{
    public class PublicacaoController : Controller
    {
        PublicacaoRepositorio publicacaoRepositorio = new PublicacaoRepositorio();
        // GET: Publicacao
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Publicar(String hashTag, String user, String conteudo)
        {
            var usuarioRepositorio = new UsuarioRepositorio();


            Publicacao publicacao = new Publicacao()
            {
                Descricao = conteudo,
                DataPublicacao = DateTime.Now,
                IdUsuario = usuarioRepositorio.BuscarPorUsername(ControleDeSessao.UsuarioAtual.Username).Id               
            };
            publicacaoRepositorio.Criar(publicacao);
            return PartialView();
        }
        public ActionResult ListarPublicacoes()
        {
            int usuarioAtual = ControleDeSessao.UsuarioAtual.IdUsuario;
            var listaDePublicacoes = publicacaoRepositorio.ListarPublicacoesDeUsuario(usuarioAtual);
            var model = new ListaDePublicacaoModel();
            foreach (var publicacao in listaDePublicacoes)
            {
                model.ListaPublicacoes.Add(new PublicacaoModel(publicacao));
            }
            return PartialView(model);
        }
    }
}