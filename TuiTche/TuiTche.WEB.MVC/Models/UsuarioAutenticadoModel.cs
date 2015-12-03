using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuiTche.Dominio;

namespace TuiTche.WEB.MVC.Models
{
    public class UsuarioAutenticadoModel
    {
        public string Username { get; private set; }
        public string Senha { get; private set; }

        public UsuarioAutenticadoModel(Usuario usuario)
        {
            this.Username = usuario.Username;
            this.Senha = usuario.Senha;
        }
    }
}