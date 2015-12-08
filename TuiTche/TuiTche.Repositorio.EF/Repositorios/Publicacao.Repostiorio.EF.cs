using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Dominio.Interfaces;
using TuiTche.Repositorio.EF.DTO;

namespace TuiTche.Repositorio.EF
{
    public class PublicacaoRepositorio : IPublicacaoRepositorio
    {
        BancoDeDados banco;

        public Publicacao BuscarPorPorId(int id)
        {
            using (banco = new BancoDeDados())
            {
                return banco.Publicacao.Include("Hashtags").Where(p => p.Id == id).FirstOrDefault();
            }
        }

        public Publicacao Criar(Publicacao publicacao)
        {
            using(banco = new BancoDeDados())
            {
                var publicacaoPronta = banco.Publicacao.Add(publicacao);
                banco.SaveChanges();
                return publicacaoPronta;
            }
        }

        public int PublicacaoTagInsert(Publicacao publicacao)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TUITCHE"].ConnectionString;
            StringBuilder builder = new StringBuilder();
            if (publicacao.Hashtags != null)
            {
                
                foreach (var tag in publicacao.Hashtags)
                {
                    builder.Append("insert into PublicacaoHashtags (IdHashtag, IdPublicacao) values(" + tag.Id + ", " + publicacao.Id + "); ");
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(builder.ToString(),connection))
            {

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
        }
            return 0;
        }

        public int AdicionarCompartilhamento(Publicacao publicacao)
        {
            using(banco = new BancoDeDados())
            {
                banco.Entry(publicacao).State = EntityState.Modified;
                return banco.SaveChanges();
            }
        }

        public IList<Publicacao> ListarPublicacoesDeSeguidores(int id, int limite)
        {
            const int quantidade = 2;
            List<Publicacao> listaPublicacoes = new List<Publicacao>();

            StringBuilder query = new StringBuilder();
            query.Append("select p.Id, p.Descricao, p.DataPublicacao, p.IdUsuario, u.NomeCompleto from Publicacao as p ");
            query.Append(" inner join Seguidores as s on p.IdUsuario = s.IdSeguindo inner join Usuario as u on p.IdUsuario = u.Id ");
            query.Append(" where s.IdSeguidor = @param or p.IdUsuario = @param order by p.DataPublicacao desc OFFSET @limite ROWS FETCH NEXT @quantidade ROWS ONLY");

            string connectionString = ConfigurationManager.ConnectionStrings["TUITCHE"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText = query.ToString();

                comando.AddParameter("param", id);
                comando.AddParameter("limite", limite);
                comando.AddParameter("quantidade", quantidade);

                connection.Open();

                IDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Publicacao publicacao = new Publicacao(Convert.ToInt32(reader["Id"]));
                    publicacao.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    publicacao.Descricao = reader["Descricao"].ToString();
                    publicacao.DataPublicacao = Convert.ToDateTime(reader["DataPublicacao"]);
                    Usuario usuario = new Usuario();
                    usuario.NomeCompleto = reader["NomeCompleto"].ToString();
                    publicacao.Usuario = usuario;
                    listaPublicacoes.Add(publicacao);
                }
                return listaPublicacoes;
                //banco.Publicacao.SqlQuery("select p.Id, p.Descricao, p.DataPublicacao, p.IdUsuario from Publicacao as p inner join Seguidores as s on p.IdUsuario = s.IdSeguindo where s.IdSeguidor = @param order by p.DataPublicacao desc", new SqlParameter("param", id));
            }
        }
        public IList<Publicacao> BuscarPublicacoesDeUsuario(int id, int limite)
        {
            const int quantidade = 2;
            using (banco = new BancoDeDados())
           {
                return banco.Publicacao.Include("Usuario").Include("Compartilhar").Where(p => p.IdUsuario == id).OrderByDescending(p => p.DataPublicacao).Skip(limite).Take(quantidade).ToList();
            }
        }
    }
}
