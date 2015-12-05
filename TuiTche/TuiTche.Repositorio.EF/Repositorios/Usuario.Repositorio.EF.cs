using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Dominio.Interfaces;
using TuiTche.Repositorio.EF;

namespace TuiTche.Repositorio.EF
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public int CadastrarUsuario(Usuario usuario)
        {
            using (var db = new BancoDeDados())
            {
              db.Usuario.Add(usuario);
                return db.SaveChanges();
            }
        }
        public int Salvar(Usuario usuario)
        {
            using (var db = new BancoDeDados())
            {
                db.Entry(usuario).State = System.Data.Entity.EntityState.Added;
                return db.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int id)
        {
            using (var db = new BancoDeDados())
            {
                return db.Usuario.Include("Seguidores").Include("Seguindo").FirstOrDefault(u => u.Id == id);
            }
        }

        public Usuario BuscarPorUsername(string username)
        {
            using (var db = new BancoDeDados())
            {
                return db.Usuario.Include("Seguidores").Include("Seguindo").FirstOrDefault(u => u.Username == username);
            }
        }

        public bool VerificarEmailEUsernameRepetido(string email,string username)
        {
            using (var db = new BancoDeDados())
            {
                return db.Usuario.Where(m => m.Email == email || m.Username == username).FirstOrDefault() == null;
            }
        }
        public IList<Usuario> BuscarTodos()
        {
            using(var db = new BancoDeDados())
            {
                return db.Usuario.Where(u => u.Username != null).ToList();
            }
        }

        public IList<Usuario> BuscarPorUsernameAutocomplete(string term)
        {
            using (var db = new BancoDeDados())
            {
                return db.Usuario.Where(u => u.Username.Contains(term)).ToList();
            }
        }
    }
}
