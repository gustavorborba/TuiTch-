using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuiTche.Dominio;

namespace TuiTche.WEB.MVC.Models
{
    public class ComentarioModel
    {
        public Publicacao Publicacao { get; set; }
        public string Texto { get; set; }
        public Usuario Usuario { get; set; }
    }
}