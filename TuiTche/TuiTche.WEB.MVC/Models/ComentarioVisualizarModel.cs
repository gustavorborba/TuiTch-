using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuiTche.Dominio;

namespace TuiTche.WEB.MVC.Models
{
    public class ComentarioVisualizarModel
    {
        public int IdPublicacao { get; set; }
        public string Texto { get; set; }
        public string Username { get; set; }
        public DateTime DataComentario { get; set; }
    }
}