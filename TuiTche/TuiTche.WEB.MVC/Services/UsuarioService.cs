using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuiTche.Dominio;
using TuiTche.Repositorio.EF;
using TuiTche.WEB.MVC.Mapper;
using TuiTche.WEB.MVC.Models;
using TuiTche.WEB.MVC.Seguranca;

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
            perfil.Seguindo = usuario.Seguidores.Where(c => c.Id == ControleDeSessao.UsuarioAtual.IdUsuario).FirstOrDefault() == null ? false : true;

            return perfil;
        }

        internal void Seguir(int idSeguidor, int idSeguindo)
        {
            repositorio.Seguir(idSeguidor, idSeguindo);
        }

        internal void PararDeSeguir(int idSeguidor, int idSeguindo)
        {
            repositorio.PaarDeSeguir(idSeguidor, idSeguindo);
        }
    }
}