using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuiTche.Dominio;
using TuiTche.Dominio.Models;

namespace TuiTche.WEB.MVC.Models
{
    public class ListaComentarioVisualizarModel
    {
        public IList<BaseComentarioVisualizarModel> Comentarios = new List<BaseComentarioVisualizarModel>();
        public int IdPublicacao { get; set; }
        public int Contador { get; set; }
    }
}