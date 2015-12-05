using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuiTche.Dominio;
using TuiTche.Dominio.Interfaces;
using TuiTche.Repositorio.EF;
using TwiTche.Repositorio.EF;

namespace TuiTche.WEB.MVC.Services
{
    public class ComentarioService
    {
        IComentarioRepositorio repositorio = new ComentarioRepositorio();

        internal void SalvarComentario(Comentario comentario)
        {
            repositorio.Salvar(comentario);
        }
    }
}