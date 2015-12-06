using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuiTche.Dominio;

namespace TuiTche.WEB.MVC.Models
{
    public class ListaComentarioVisualizarModel
    {
        public IList<ComentarioVisualizarModel> Comentarios = new List<ComentarioVisualizarModel>();
        public int IdPublicacao { get; set; }
        public int Contador { get; set; }
    }
}