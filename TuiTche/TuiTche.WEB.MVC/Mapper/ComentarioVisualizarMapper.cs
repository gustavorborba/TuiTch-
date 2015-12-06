using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuiTche.Dominio;
using TuiTche.WEB.MVC.Models;

namespace TuiTche.WEB.MVC.Mapper
{
    public class ComentarioVisualizarMapper
    {
        public static ComentarioVisualizarModel EntityToModel(Comentario comentario)
        {
            ComentarioVisualizarModel model = new ComentarioVisualizarModel();
            model.Texto = comentario.Texto;
            model.IdPublicacao = comentario.IdPublicacao;
            model.Username = comentario.Usuario.Username;
            model.DataComentario = comentario.DataComentario;

            return model;
        }
    }
}