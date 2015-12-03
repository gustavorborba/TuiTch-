using Services.CriptografiaService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuiTche.Dominio.Services.Criptografia;
using TuiTche.WEB.MVC.Models;
using TwiTche.Repositorio.EF;

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
                    
                }

            }
            return null;
        }
    }
}