using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuiTche.WEB.MVC.Models
{
    public class ListaDePublicacaoModel
    {
        public IList<PublicacaoModel> ListaPublicacoes { get; set; }

        public ListaDePublicacaoModel()
        {
            this.ListaPublicacoes = new List<PublicacaoModel>();
        }
    }
}