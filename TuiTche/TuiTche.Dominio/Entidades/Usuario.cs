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
        public Pontuacao Pontuacao { get; set; }

        public virtual ICollection<Usuario> Seguindo { get; set; }

        public virtual ICollection<Usuario> Seguidores { get; set; }

        public virtual ICollection<Publicacao> Publicacao { get; set; }

        public virtual ICollection<Compartilhar> Compartilhar { get; set; }

        public enum Sexo
        {
            MASCULINO = 1,
            FEMININO = 2
        }

        public Usuario()
        {
            Seguindo = new List<Usuario>();
            Seguidores = new List<Usuario>();
        }

        public Usuario(string username, int id = 0) : this()
        {
            Id = id;
            Username = username;
        }

        public override bool Equals(object obj)
        {
            Usuario usuario = (Usuario)obj;
            return this.Id == usuario.Id && this.Username == usuario.Username &&
                this.NomeCompleto == usuario.NomeCompleto && this.Email == usuario.Email &&
                this.Senha == usuario.Senha && this.SexoUsuario == usuario.SexoUsuario &&
                this.Foto == usuario.Foto;
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Username: {1}, Nome: {2}, Email: {3}, Senha: {4}, Sexo: {5}, Foto: {6}", this.Id, this.Username, this.NomeCompleto,
                this.Email, this.Senha, this.SexoUsuario.ToString(), this.Foto);
        }

        public void SeguirUsuario(Usuario seguir)
        {            
            Seguindo.Add(seguir);
        }

    }
}
