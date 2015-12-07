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
    public class UsuarioService
    {
        private BasePerfilModel model;
        private IPerfilMapper mapper;
        private IUsuarioRepositorio repositorio;
        public int IdUsuarioAtual;

        public UsuarioService(BasePerfilModel model, IPerfilMapper mapper, IUsuarioRepositorio repositorio, int idUsuarioAtual)
        {
            this.model = model;
            this.mapper = mapper;
            this.repositorio = repositorio;
            IdUsuarioAtual = idUsuarioAtual;
        }

        public Usuario BuscarPorId(int id)
        {
            return repositorio.BuscarPorId(id);
        }

        public BasePerfilModel BuscarPorUsername(string username)
        {
            Usuario usuario = repositorio.BuscarPorUsername(username);
            BasePerfilModel perfil = mapper.toModel(usuario);
            perfil.NumeroSeguidores = usuario.Seguidores.Count();
            perfil.NumeroSeguindo = usuario.Seguindo.Count();
            perfil.Seguindo = usuario.Seguidores.Where(c => c.Id == IdUsuarioAtual).FirstOrDefault() == null ? false : true;

            return perfil;
        }

        public void Seguir(int idSeguidor, int idSeguindo)
        {
            repositorio.Seguir(idSeguidor, idSeguindo);
        }

        public void PararDeSeguir(int idSeguidor, int idSeguindo)
        {
            repositorio.PararDeSeguir(idSeguidor, idSeguindo);
        }
    }
}