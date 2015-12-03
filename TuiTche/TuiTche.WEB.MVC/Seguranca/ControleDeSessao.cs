using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using TuiTche.Dominio;
using TuiTche.WEB.MVC.Models;

namespace TuiTche.WEB.MVC.Seguranca
{
    public class ControleDeSessao
    {
        private const string USUARIOATUAL = "USUARIO_AUTENTICADO";
        public static UsuarioAutenticadoModel UsuarioAtual
        {
            get
            {
                return HttpContext.Current.Session[USUARIOATUAL] as UsuarioAutenticadoModel;
            }
        }

        public static void CriarSessaoDeUsuario(Usuario usuario)
        {
            var usuarioLogado = new UsuarioAutenticadoModel(usuario);
            FormsAuthentication.SetAuthCookie(usuarioLogado.Username, true);
            HttpContext.Current.Session[USUARIOATUAL] = usuarioLogado;
        }

        public static void Encerrar()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Session.Abandon();
        }
    }
}