using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuiTche.Dominio;
using TuiTche.Dominio.Services;
using TuiTche.Repositorio.EF;
using TuiTche.Repositorio.EF.Repositorios;
using TuiTche.WEB.MVC.Mapper;
using TuiTche.WEB.MVC.Models;
using TuiTche.WEB.MVC.Seguranca;
using TuiTche.WEB.MVC.Services;

namespace TuiTche.WEB.MVC.Controllers
{
    public class PublicacaoController : Controller
    {
        PublicacaoRepositorio publicacaoRepositorio = new PublicacaoRepositorio();
        HashtagRepositorio hashtagRepositorio = new HashtagRepositorio();
        UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
        CurtirRepositorio curtirRepositorio = new CurtirRepositorio();
        ComentarioService comentarioService = new ComentarioService();

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
            publicacaoRepositorio.Criar(publicacao);
            if (hashtags != null)
            {
                publicacao = UpdateNasUtilizacoesDasTagsGauderias(hashtags, publicacao);
                int x = publicacaoRepositorio.PublicacaoTagInsert(publicacao);
                publicacao.Hashtags = null;
            }
            return PartialView("_Publicar");
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
                    publicacao.Hashtags.Add(hashtagGauderia);
                }
                else
                {
                    Hashtag hashtag = hashtagRepositorio.Criar(tag);
                    publicacao.Hashtags.Add(hashtag);
                }
                
            }
            return publicacao;
        }

        private ActionResult CurtirPublicacao(int idPublicacao,int idUsuarioPublicacao)
        {
            CurtirService service = new CurtirService(new CurtirRepositorio(),new PontuacaoRepositorio());
            service.CurtirPublicacao(idPublicacao, idUsuarioPublicacao , ControleDeSessao.UsuarioAtual.IdUsuario);

            return PartialView();
        }
        public JsonResult UsuarioAutocomplete(string term)
        {
            var usuariosEncontrados = term == null ? usuarioRepositorio.BuscarTodos() : usuarioRepositorio.BuscarPorUsernameAutocomplete(term);
            var json = usuariosEncontrados.Select(x => new { label= x.Username });

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UsuarioAutocompleteArray(string term)
        {
            var usuariosEncontrados = term == null ? usuarioRepositorio.BuscarTodos() : usuarioRepositorio.BuscarPorUsernameAutocomplete(term);
            string[] json = usuariosEncontrados.Select(x => x.Username).ToArray();

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult HashtagAutocomplete(string term)
        {
            var tagsEncontradas = term == null ? hashtagRepositorio.BuscarTodos() : hashtagRepositorio.BuscarPorPalavra(term);
            var json = tagsEncontradas.Select(x => new { label = x.Palavra });

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult _Comentar(int IdPublicacao)
        {
            ComentarioModel model = new ComentarioModel()
            {
                IdPublicacao = IdPublicacao,
                IdUsuario = ControleDeSessao.UsuarioAtual.IdUsuario
            };
            return PartialView(model);
        }

        public ActionResult _CarregarComentarios(int idPublicacao)
        {
            ListaComentarioVisualizarModel model = new ListaComentarioVisualizarModel()
            {
                Contador = 0,
                IdPublicacao = idPublicacao
            };
            IList<Comentario> comentarios = comentarioService.BuscarProximos(idPublicacao, null);

            foreach (Comentario comentario in comentarios)
            {
                model.Comentarios.Add(ComentarioVisualizarMapper.EntityToModel(comentario));
            }
            
            return PartialView(model);
        }

        public JsonResult CarregarMaisComentarios(int idPublicacao, int? contador)
        {
            contador += 2;
            ListaComentarioVisualizarModel model = new ListaComentarioVisualizarModel() {
                Contador = (int)contador,
                IdPublicacao = idPublicacao
            };

            IList<Comentario> comentarios = comentarioService.BuscarProximos(idPublicacao, contador);

            foreach (Comentario comentario in comentarios)
            {
                model.Comentarios.Add(ComentarioVisualizarMapper.EntityToModel(comentario));
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SalvarComentario(ComentarioModel model)
        {
            model.DataComentario = DateTime.Now;
            comentarioService.SalvarComentario(ComentarioMapper.ModelToEntity(model));

            return View("Index");
        }
    }
}