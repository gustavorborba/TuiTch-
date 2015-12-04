using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TuiTche.Dominio;

namespace TuiTche.WEB.MVC.Models
{
    public class UsuarioAutenticadoModel
    {
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Username { get;  set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Senha { get;  set; }

        public UsuarioAutenticadoModel(Usuario usuario)
        {
            this.Username = usuario.Username;
            this.Senha = usuario.Senha;
        }

        public UsuarioAutenticadoModel()
        {

        }
    }
}