using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Repositorio.EF;

namespace TwiTche.Repositorio.EF
{
    public class RepositorioUsuario
    {
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
    }
}
