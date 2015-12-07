using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio.Interfaces;

namespace TuiTche.Dominio.Services.RegrasDeNegocio
{
    public class UsuarioService
    {
        IUsuarioRepositorio repositorio;

        public UsuarioService(IUsuarioRepositorio repositorio)
        {
            this.repositorio = repositorio;
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
