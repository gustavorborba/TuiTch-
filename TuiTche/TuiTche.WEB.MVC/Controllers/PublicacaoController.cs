using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using TuiTche.Dominio;
using TuiTche.Dominio.Services;
using TuiTche.Repositorio.EF;
using TuiTche.Repositorio.EF.Repositorios;
using TuiTche.WEB.MVC.Extensoes;
using TuiTche.WEB.MVC.Mapper;
using TuiTche.WEB.MVC.Models;
using TuiTche.WEB.MVC.Seguranca;

namespace TuiTche.WEB.MVC.Controllers
{
    [Authorize]
    public class PublicacaoController : Controller
    {
        PublicacaoRepositorio PublicacaoRepositorio = new PublicacaoRepositorio();
        HashtagRepositorio HashtagRepositorio = new HashtagRepositorio();
        UsuarioRepositorio UsuarioRepositorio = new UsuarioRepositorio();
        CurtirRepositorio CurtirRepositorio = new CurtirRepositorio();
        PontuacaoRepositorio PontuacaoRepositorio = new PontuacaoRepositorio();
        ComentarioVisualizarMapper mapper = new ComentarioVisualizarMapper();
        ComentarioActions comentarioActions = new ComentarioActions();
        CompartilharRepositorio CompartilharRepositorio = new CompartilharRepositorio();

        // GET: Publicacao
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Publicar(String[] hashtags, String[] users, String conteudo)
        {
            if (conteudo != null)
            {
                Publicacao publicacao = new Publicacao()
                {
                    Descricao = conteudo,
                    DataPublicacao = DateTime.Now,
                    IdUsuario = UsuarioRepositorio.BuscarPorUsername(ControleDeSessao.UsuarioAtual.Username).Id
                };
                PublicacaoRepositorio.Criar(publicacao);
                Pontuacao pontuacao = PontuacaoRepositorio.BuscarPontos(publicacao.IdUsuario);
                pontuacao.PontuacaoTotal += 15;
                PontuacaoRepositorio.SomarPontos(pontuacao);
                if (hashtags != null)
                {
                    publicacao = UpdateNasUtilizacoesDasTagsGauderias(hashtags, publicacao);
                    int x = PublicacaoRepositorio.PublicacaoTagInsert(publicacao);
                    publicacao.Hashtags = null;
                }
            }
            return PartialView("_Publicar");
        }


        public ActionResult BuscarMensagemPorTag(String hashtag)
        {
            IList<Publicacao> publicacoes = PublicacaoRepositorio.BuscarPublicacoes(hashtag);
            var publicacoesModel = new ListaDePublicacaoModel();
            if (publicacoes == null)
            {
                ViewBag.ListaVazia = "Não há publicações com esta hashtag!";
            }
            else
            {
                foreach (var publicacao in publicacoes)
                {
                    publicacao.Usuario = UsuarioRepositorio.BuscarPorId(publicacao.IdUsuario);
                    publicacoesModel.ListaPublicacoes.Add(new PublicacaoModel(publicacao));
                }
            }
            return View("BuscarMensagem", publicacoesModel);
        }

        private Publicacao UpdateNasUtilizacoesDasTagsGauderias(String[] hashtags, Publicacao publicacao)
        {
            foreach (var tag in hashtags)
            {
                var hashtagGauderia = HashtagRepositorio.VerificaSeTagEGauderia(tag);
                
                if (hashtagGauderia != null)
                {
                    Pontuacao pontuacao = PontuacaoRepositorio.BuscarPontos(publicacao.IdUsuario);
                    pontuacao.PontuacaoTotal += 10;
                    PontuacaoRepositorio.SomarPontos(pontuacao);
                    int i = HashtagRepositorio.UpdatePontuacao(hashtagGauderia.Id);
                    publicacao.Hashtags.Add(hashtagGauderia);
                }
                else
                {
                    Hashtag hashtag = HashtagRepositorio.Criar(tag);
                    publicacao.Hashtags.Add(hashtag);
                }
                
            }
            return publicacao;
        }
        public ActionResult Compartilhar(String idPublicacao)
        {
            Compartilhar compartilhar = new Compartilhar();
            compartilhar.DataCompartilhamento = DateTime.Now;
            compartilhar.IdPublicacao = Convert.ToInt32(idPublicacao);
            compartilhar.IdUsuario = ControleDeSessao.UsuarioAtual.IdUsuario;
            Pontuacao pontuacao = PontuacaoRepositorio.BuscarPontos(compartilhar.IdUsuario);
            pontuacao.PontuacaoTotal += 20;
            PontuacaoRepositorio.SomarPontos(pontuacao);
            Publicacao publicacao = PublicacaoRepositorio.BuscarPorPorId(compartilhar.IdPublicacao);
            Publicacao publicacaoCompartilhada = new Publicacao()
            {
                IdUsuario = publicacao.IdUsuario,
                DataPublicacao = compartilhar.DataCompartilhamento,
                Descricao = publicacao.Descricao
            };
            Publicacao afetada = PublicacaoRepositorio.Criar(publicacaoCompartilhada);
            compartilhar.IdPublicacao = afetada.Id;
            Compartilhar compartilhamento = CompartilharRepositorio.Compartilhar(compartilhar);
            afetada.Compartilhar = new List<Compartilhar>();
            afetada.Compartilhar.Add(compartilhar);
            int linhas = PublicacaoRepositorio.AdicionarCompartilhamento(afetada);
            
            

            return View("../Publicacao/Index");
        }

        private ActionResult CurtirPublicacao(int idPublicacao,int idUsuarioPublicacao)
        {
            CurtirService service = new CurtirService(new CurtirRepositorio(),new PontuacaoRepositorio());
            service.CurtirPublicacao(idPublicacao, idUsuarioPublicacao , ControleDeSessao.UsuarioAtual.IdUsuario);

            return PartialView();
        }
        public JsonResult UsuarioAutocomplete(string term)
        {
            var usuariosEncontrados = term == null ? UsuarioRepositorio.BuscarTodos() : UsuarioRepositorio.BuscarPorUsernameAutocomplete(term);
            var json = usuariosEncontrados.Select(x => new { label= x.Username });

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UsuarioAutocompleteArray(string term)
        {
            var usuariosEncontrados = term == null ? UsuarioRepositorio.BuscarTodos() : UsuarioRepositorio.BuscarPorUsernameAutocomplete(term);
            string[] json = usuariosEncontrados.Select(x => x.Username).ToArray();

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult HashtagAutocomplete()
        {
            var tagsEncontradas = HashtagRepositorio.BuscarTodos();
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

            IList<Comentario> comentarios = comentarioActions.BuscarProximos(idPublicacao, null);

            foreach (Comentario comentario in comentarios)
            {
                model.Comentarios.Add(ComentarioVisualizarMapper.EntityToModel(comentario));
            }

            return PartialView(model);
        }

        public ActionResult CarregarMaisComentarios(int idPublicacao, int? contador)
        {
            ListaComentarioVisualizarModel model = new ListaComentarioVisualizarModel() {
                Contador = (int)contador,
                IdPublicacao = idPublicacao
            };


            IList<Comentario> comentarios = comentarioActions.BuscarProximos(idPublicacao, contador);


            foreach (Comentario comentario in comentarios)
            {
                model.Comentarios.Add(ComentarioVisualizarMapper.EntityToModel(comentario));
            }

            return PartialView("_Comentarios", model);
        }

        [HttpPost]
        public ActionResult SalvarComentario(ComentarioModel model)
        {
            model.DataComentario = DateTime.Now;
            if (model.Texto != null && model.Texto.Length > 0) {
                comentarioActions.SalvarComentario(ComentarioMapper.ModelToEntity(model));
            }
            return RedirectToAction("CarregarMaisComentarios", new { idPublicacao = model.IdPublicacao, contador = 0 });
        }
    }
}