using Services.CriptografiaService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuiTche.Dominio.Services.Criptografia;
using TuiTche.Repositorio.EF;
using TuiTche.WEB.MVC.Models;
using TuiTche.WEB.MVC.Seguranca;

namespace TuiTche.WEB.MVC.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginUsuario(UsuarioAutenticadoModel usuario)
        {
            if (ModelState.IsValid)
            {
                AutenticarUsuario autenticar = new AutenticarUsuario(new UsuarioRepositorio(), new CriptografiaService());
                var usuarioAutenticado = autenticar.validarUsuario(usuario.Username, usuario.Senha);
                if(usuarioAutenticado != null)
                {
                    ControleDeSessao.CriarSessaoDeUsuario(usuarioAutenticado);
                    return RedirectToAction("Index", "Publicacao");
                }
            }
            TempData["Login"] = "Usuário ou senha inválidos";
            return View("Index", usuario);
        }

        public ActionResult Encerrar()
        {
            ControleDeSessao.Encerrar();
            return RedirectToAction("Index", "Login");
        }
    }
}