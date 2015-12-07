using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Dominio.Interfaces;
using TuiTche.Repositorio.EF;
using TuiTche.Repositorio.EF.DTO;

namespace TuiTche.Repositorio.EF
{
    public class CompartilharRepositorio : ICompartilharRepositorio
    {
        BancoDeDados banco;

        public Compartilhar BuscarPorId(int id)
        {   
            using (banco = new BancoDeDados())
            {
                return banco.Compartilhar.Include("Usuario").Include("Publicacao").Where(c => c.Id == id).First();
            }
        }

        public int Compartilhar(Compartilhar compartilhar)
        {
            using (banco = new BancoDeDados())
            {
                banco.Compartilhar.Add(compartilhar);
                return banco.SaveChanges();
            }
        }

        public List<Compartilhar> BuscarCompartilhamentos(Publicacao publicacao,int limite)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TUITCHE"].ConnectionString;
            //TODO: Debater sobre como fazer para mostrar as mensagens retwitadas/compartilhadas.
            StringBuilder query = new StringBuilder();

            List<Compartilhar> compartilhamentos = new List<Compartilhar>();
            query.Append("select * from Compartilhar as c "
            + " inner join Seguidores s on c.IdUsuario = s.IdSeguindo "
            + " where c.IdPublicacao = @idPublicacao and c.IdUsuario = @usuario "
            + " order by c.DataCompartilhamento desc;");
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();
                comando.CommandText = query.ToString();
                comando.AddParameter("idPublicacao", publicacao.Id);
                comando.AddParameter("usuario", publicacao.IdUsuario);

                connection.Open();
                IDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Compartilhar compartilhar = new Dominio.Compartilhar(Convert.ToInt32(reader["Id"]));
                    compartilhar.DataCompartilhamento = Convert.ToDateTime(reader["DataCompartilhamento"]);
                    compartilhar.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    compartilhar.IdPublicacao = Convert.ToInt32(reader["IdPublicacao"]);
                    compartilhamentos.Add(compartilhar);
                }
                return compartilhamentos;
            }
        }
    }
}
