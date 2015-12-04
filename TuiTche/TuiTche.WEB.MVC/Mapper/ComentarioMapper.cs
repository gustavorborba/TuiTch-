using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuiTche.Dominio;
using TuiTche.WEB.MVC.Models;

namespace TuiTche.WEB.MVC.Mapper
{
    public class ComentarioMapper
    {
        public static ComentarioModel EntityToModel(Comentario comentario)
        {
            ComentarioModel model = new ComentarioModel();
            model.Texto = comentario.Texto;
            model.Publicacao = comentario.Publicacao;
            model.Usuario = comentario.Usuario;

            return model;
        }

        public static Comentario ModelToEntity(ComentarioModel model)
        {
            Comentario comentario = new Comentario();
            comentario.Texto = model.Texto;
            comentario.Publicacao = model.Publicacao;
            comentario.Usuario = model.Usuario;

            return comentario;
        }
    }
}