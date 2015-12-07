using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuiTche.Dominio;
using TuiTche.Dominio.Interfaces;
using TuiTche.Repositorio.EF;
using TuiTche.WEB.MVC.Mapper;
using TuiTche.WEB.MVC.Models;
using TwiTche.Repositorio.EF;

namespace TuiTche.WEB.MVC.Extensoes
{
    public class ComentarioActions
    {
        IComentarioRepositorio repositorio = new ComentarioRepositorio();

        internal void SalvarComentario(Comentario comentario)
        {
            repositorio.Salvar(comentario);
        }

        internal IList<ComentarioVisualizarModel> buscarComentariosDaPublicacao(int idPublicacao)
        {
            IList<Comentario> comentarios = repositorio.BuscarListaComIdPublicacao(idPublicacao);
            IList<ComentarioVisualizarModel> model = new List<ComentarioVisualizarModel>();
            foreach (Comentario comentario in comentarios)
            {
                model.Add(ComentarioVisualizarMapper.EntityToModel(comentario));
            }

            return model;
        }

        internal IList<Comentario> BuscarProximos(int idPublicacao, int? contador)
        {
            return repositorio.BuscarProximosComIdPublicacao(idPublicacao, contador);
        }
    }
}