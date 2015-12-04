using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuiTche.WEB.MVC.Models
{
    public class MensagemModel
    {
        public int IdPublicacao { get; set; }
        public IList<int> Hashtags { get; set; }
        public string Mensagem { get; set; }
    }
}