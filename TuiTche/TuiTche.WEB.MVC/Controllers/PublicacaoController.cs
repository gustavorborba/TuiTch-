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
        public ActionResult Publicar(String hashtag, String user, String conteudo)
        {
            var usuarioRepositorio = new UsuarioRepositorio();

            var publicacaoRepositorio = new PublicacaoRepositorio();
            var hashtagRepositorio = new HashtagRepositorio();

            Publicacao publicacao = new Publicacao()
            {
                Descricao = conteudo,
                DataPublicacao = DateTime.Now,
                IdUsuario = usuarioRepositorio.BuscarPorUsername(ControleDeSessao.UsuarioAtual.Username).Id               
            };
            var hashtagGauderia = hashtagRepositorio.VerificaSeTagEGauderia(hashtag);
            if (hashtagGauderia != null)
            {
                //hashtagGauderia.Publicacoes.Add(publicacao);
                hashtagRepositorio.Salvar(hashtagGauderia);
                int i = hashtagRepositorio.UpdatePontuacao(hashtagGauderia.Id);
            }
            publicacao.Hashtags.Add(hashtagGauderia);
            publicacaoRepositorio.Criar(publicacao);
            return PartialView("_Publicar");
        }
        public ActionResult _ListarPublicacoes()
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