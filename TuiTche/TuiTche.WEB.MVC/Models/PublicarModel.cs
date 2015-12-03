using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuiTche.WEB.MVC.Models
{
    public class PublicarModel
    {
        public int IdCliente { get; set; }
        public String Conteudo { get; set; }
        public DateTime DataPublicacao { get; set; }
    }
}