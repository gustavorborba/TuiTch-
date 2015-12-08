using Services.CriptografiaService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TuiTche.Dominio;
using TuiTche.Dominio.Services;
using TuiTche.Dominio.Services.RegrasDeNegocio;
using TuiTche.Repositorio.EF;
using TuiTche.Repositorio.EF.Repositorios;
using TuiTche.WEB.MVC.Extensoes;
using TuiTche.WEB.MVC.Mapper;
using TuiTche.WEB.MVC.Models;
using TuiTche.WEB.MVC.Seguranca;

namespace TuiTche.WEB.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioRepositorio UsuarioRepositorio = new UsuarioRepositorio();
        UsuarioActions usuarioActions = new UsuarioActions();
        UsuarioService usuarioService = new UsuarioService(new UsuarioRepositorio(), new PontuacaoRepositorio());
        CriptografiaService criptografia = new CriptografiaService();
        PontuacaoService pontuacaoService = new PontuacaoService(new PontuacaoRepositorio());
        // GET: Usuario
        public ActionResult index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View("CadastrarUsuario");
        }
        [HttpGet]
        public ActionResult perfil(string username)
        {
            PerfilModel model = usuarioActions.BuscarPorUsername(username);
            return View(model);
        }

        public ActionResult CadastrarUsuario(UsuarioModel model)
        {
            bool usuarioRepetido = UsuarioRepositorio.VerificarEmailEUsernameRepetido(model.Email, model.Username);

            if (!usuarioRepetido)
            {
                TempData["Mensagem"] = "Usuário e/ou Email já se encontram na base de dados";
                return View("CadastrarUsuario", model);
            }

            bool senhasCoincidem = criptografia.SenhasIdenticas(model.Senha, model.ConfirmarSenha);
            bool senhasEmBranco = model.Senha != null && model.ConfirmarSenha != null;
            if (!senhasCoincidem && senhasEmBranco)
            {
                TempData["Mensagem"] = "Senhas não coincidem";
                return View("CadastrarUsuario", model);
            }

            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario(model.Username)
                {
                    NomeCompleto = model.NomeCompleto,
                    Senha = criptografia.Criptografar(model.Senha),
                    Email = model.Email,
                    SexoUsuario = model.Sexo,
                    
                };
                //de todas as gambiarras, essa é uma das que mais doeu fazer, acredite doeu mais escrever isso
                if(model.FotoPerfil != null)
                {
                     string file = Path.GetFileName(model.FotoPerfil.FileName);
                     string local = Path.Combine(Server.MapPath("~/Content/img-upload/"), model.Username + ".jpg");
                     model.FotoPerfil.SaveAs(local);
                     usuario.Foto = "~/Content/img-upload/" + usuario.Username;
                }
                usuario.Pontuacao = new Pontuacao()
                {
                    PontuacaoTotal = 0
                };
                UsuarioRepositorio.CadastrarUsuario(usuario);
                TempData["Mensagem"] = "Usuario Cadastrado com Sucesso!";
                return RedirectToAction("Index", "Login");
            }
            TempData["Mensagem"] = "Ocorreu os seguintes erros: ";
            return View("CadastrarUsuario", model);
        }

        [HttpPost]
        public ActionResult Seguir(int idSeguidor, int idSeguindo, string username)
        {
            usuarioService.Seguir(idSeguidor, idSeguindo);

            return RedirectToAction("perfil", new { username = username });
        }

        [HttpPost]
        public ActionResult PararDeSeguir(int idSeguidor, int idSeguindo, string username)
        {
            usuarioService.PararDeSeguir(idSeguidor, idSeguindo);

            return RedirectToAction("perfil", new { username = username });
        }

        public ActionResult BuscarInformacoesUsuario()
        {
            Usuario usuarioInformacoes = UsuarioRepositorio.BuscarPorId(ControleDeSessao.UsuarioAtual.IdUsuario);
            InformacoesUsuarioModel informacoes = new InformacoesUsuarioModel();
            if(usuarioInformacoes.Foto != null)
            {
                informacoes.FotoPerfil = usuarioInformacoes.Foto.Replace('\\', '/') + ".jpg";
            }
            informacoes.NomeCompleto = usuarioInformacoes.NomeCompleto;
            informacoes.RankingUsuario = pontuacaoService.BuscarRankingUsuario(usuarioInformacoes.Id).ToString();
            return PartialView("BaseInformacoesUsuario", informacoes);
        }
    }
}