using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuiTche.Dominio
{
    public class Usuario : EntidadeBase
    {
        public string Username { get; private set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Sexo SexoUsuario { get; set; }
        public string Foto { get; set; }

        public enum Sexo
        {
            MASCULINO = 1,
            FEMININO = 2
        }

        public Usuario()
        {

        }

        public Usuario(int id)
        {
            Id = id;
        }

    }
}
