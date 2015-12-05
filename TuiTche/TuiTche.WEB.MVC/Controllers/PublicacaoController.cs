using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuiTche.Dominio;
using TuiTche.Repositorio.EF;
using TuiTche.Repositorio.EF.Repositorios;
using TuiTche.WEB.MVC.Models;
using TuiTche.WEB.MVC.Seguranca;

namespace TuiTche.WEB.MVC.Controllers
{
    public class PublicacaoController : Controller
    {
        PublicacaoRepositorio publicacaoRepositorio = new PublicacaoRepositorio();
        HashtagRepositorio hashtagRepositorio = new HashtagRepositorio();
        UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
        CurtirRepositorio curtirRepositorio = new CurtirRepositorio();
        // GET: Publicacao
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Publicar(String[] hashtags, String[] users, String conteudo)
        {
            Publicacao publicacao = new Publicacao()
            {
                Descricao = conteudo,
                DataPublicacao = DateTime.Now,
                IdUsuario = usuarioRepositorio.BuscarPorUsername(ControleDeSessao.UsuarioAtual.Username).Id
            };

            if (hashtags != null)
            { 
                publicacao = UpdateNasUtilizacoesDasTagsGauderias(hashtags, publicacao);
            }
            publicacaoRepositorio.Criar(publicacao);
            return PartialView("_Publicar");
        }
        public ActionResult _ListarPublicacoes()
        {
            int usuarioAtual = ControleDeSessao.UsuarioAtual.IdUsuario;
            var listaDePublicacoes = publicacaoRepositorio.GerarTimeLine(usuarioAtual);
            var model = new ListaDePublicacaoModel();
            foreach (var publicacao in listaDePublicacoes)
            {
                model.ListaPublicacoes.Add(new PublicacaoModel(publicacao));
            }
            return PartialView(model);
        }

        private Publicacao UpdateNasUtilizacoesDasTagsGauderias(String[] hashtags, Publicacao publicacao)
        {
            foreach (var tag in hashtags)
            {
                var hashtagGauderia = hashtagRepositorio.VerificaSeTagEGauderia(tag);
                if (hashtagGauderia != null)
                {
                    //hashtagGauderia.Publicacoes.Add(publicacao);
                    int i = hashtagRepositorio.UpdatePontuacao(hashtagGauderia.Id);
                }
                publicacao.Hashtags.Add(hashtagGauderia);
            }
            return publicacao;
        }
        private ActionResult CurtirPublicacao(int idPublicacao,int idUsuarioPublicacao)
        {
            curtirRepositorio.CurtirPublicacao(idPublicacao, idUsuarioPublicacao , ControleDeSessao.UsuarioAtual.IdUsuario);

            return PartialView();
        }
    }
}