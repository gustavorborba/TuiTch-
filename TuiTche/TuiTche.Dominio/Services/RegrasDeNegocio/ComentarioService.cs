using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuiTche.Dominio;
using TuiTche.Dominio.Interfaces;
using TuiTche.Dominio.Mapper;
using TuiTche.Dominio.Models;

namespace TuiTche.Dominio.Services
{
    public class ComentarioService
    {

        IComentarioRepositorio repositorio;
        BaseComentarioVisualizarModel model;
        IComentarioVisualizarMapper mapper;

        public ComentarioService(IComentarioRepositorio repositorio, BaseComentarioVisualizarModel model,
            IComentarioVisualizarMapper mapper)
        {
            this.repositorio = repositorio;
            this.model = model;
            this.mapper = mapper;
        }

        public void SalvarComentario(Comentario comentario)
        {
            repositorio.Salvar(comentario);
        }

        public IList<BaseComentarioVisualizarModel> buscarComentariosDaPublicacao(int idPublicacao)
        {
            IList<Comentario> comentarios = repositorio.BuscarListaComIdPublicacao(idPublicacao);
            IList<BaseComentarioVisualizarModel> model = new List<BaseComentarioVisualizarModel>();
            foreach (Comentario comentario in comentarios) {
                model.Add(mapper.EntityToModel(comentario));
            }

            return model;
        }

        public IList<Comentario> BuscarProximos(int idPublicacao, int? contador)
        {
            return repositorio.BuscarProximosComIdPublicacao(idPublicacao, contador);
        }
    }
}

