using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio.Interfaces;

namespace TuiTche.Dominio.Services.Criptografia
{
    public class AutenticarUsuario
    {
        public IUsuarioRepositorio usuarioRepositorio;
        public IServicoCriptografia servicoCriptografia;

        public AutenticarUsuario(IUsuarioRepositorio usuarioRepositorio, IServicoCriptografia servicoCriptografia)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            this.servicoCriptografia = servicoCriptografia;
        }

        public Usuario validarUsuario(string username, string senha)
        {
            var usuario = usuarioRepositorio.BuscarPorUsername(username);
            bool usuarioNaoEncontrado = usuario == null;
            senha = servicoCriptografia.Criptografar(senha);
            bool senhaCorrespondem = usuario.Senha == senha;
            if(usuarioNaoEncontrado)
            {
                return null;
            }
            if (senhaCorrespondem)
            {
                return usuario;
            }
            return null;
        }
    }
}
