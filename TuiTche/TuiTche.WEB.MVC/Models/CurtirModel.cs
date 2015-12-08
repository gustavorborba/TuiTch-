using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuiTche.Dominio;

namespace TuiTche.WEB.MVC.Models
{
    public class CurtirModel
    {
        public int IdPublicacao { get; set; }
        public int IdUsuarioPublicacao { get; set; }
        public int Curtidas { get; set; }
        public int IdUsuario { get; set; }
        public bool Curtido { get; set; }
    }
}