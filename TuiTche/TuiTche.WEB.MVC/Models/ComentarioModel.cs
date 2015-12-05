using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuiTche.Dominio;

namespace TuiTche.WEB.MVC.Models
{
    public class ComentarioModel
    {
        public int IdPublicacao { get; set; }
        public string Texto { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataComentario { get; set; }
    }
}