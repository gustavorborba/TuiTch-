using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
                if (usuario.Id > 0)
                {
                    db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    db.Entry(usuario).State = System.Data.Entity.EntityState.Added;
                }
                
                db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public void Seguir(int idSeguidor, int idSeguido)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TUITCHE"].ConnectionString;
            StringBuilder builder = new StringBuilder();
            builder.Append("INSERT INTO Seguidores (IdSeguidor, IdSeguindo) values(" + idSeguidor + ", " + idSeguido + "); ");

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(builder.ToString(), connection))
            {

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void PaarDeSeguir(int idSeguidor, int idSeguido)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TUITCHE"].ConnectionString;
            StringBuilder builder = new StringBuilder();
            builder.Append("DELETE FROM Seguidores WHERE IdSeguidor = " + idSeguidor + " and IdSeguindo = " + idSeguido + "; ");

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(builder.ToString(), connection))
            {

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
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
