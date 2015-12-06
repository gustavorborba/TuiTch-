using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuiTche.Dominio;
using TuiTche.Repositorio.EF;
using TuiTche.WEB.MVC.Mapper;
using TuiTche.WEB.MVC.Models;

namespace TuiTche.WEB.MVC.Services
{
    public class UsuarioService
    {
        private UsuarioRepositorio repositorio = new UsuarioRepositorio();

        internal Usuario BuscarPorId(int id)
        {
            return repositorio.BuscarPorId(id);
        }

        internal PerfilModel BuscarPorUsername(string username)
        {
            Usuario usuario = repositorio.BuscarPorUsername(username);
            PerfilModel perfil = PerfilMapper.toModel(usuario);
            perfil.NumeroSeguidores = usuario.Seguidores.Count();
            perfil.NumeroSeguindo = usuario.Seguindo.Count();

            return perfil;
        }
    }
}