using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuiTche.Repositorio.EF;

namespace TuiTche.WEB.MVC.Services
{
    public class UsuarioService
    {
        private UsuarioRepositorio repositorio = new UsuarioRepositorio();

        internal Dominio.Usuario BuscarPorId(int id)
        {
            return repositorio.BuscarPorId(id);
        }
    }
}