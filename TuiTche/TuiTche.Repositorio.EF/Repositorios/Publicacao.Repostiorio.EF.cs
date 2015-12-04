using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;

namespace TuiTche.Repositorio.EF
{
    public class PublicacaoRepositorio
    {
        BancoDeDados banco;

        public Publicacao BuscarPorPorId(int id)
        {
            using (banco = new BancoDeDados())
            {
                 return banco.Publicacao.Find(id);
            }
        }
        public int Criar(Publicacao publicacao)
        {
            using(banco = new BancoDeDados())
            {
                banco.Publicacao.Add(publicacao);
                return banco.SaveChanges();
            }
        }
        public IList<Publicacao> ListarPublicacoesDeUsuario(int id)
        {
            using (banco = new BancoDeDados())
            {
                 return banco.Publicacao.SqlQuery("select * from Publicacao as p inner join Seguidores as s on p.IdUsuario = s.IdSeguindo where s.IdSeguidor = @param", new SqlParameter("param",id)).ToList();
                    //select* from Publicacao as p inner join Seguidores as s on p.IdUsuario = s.IdSeguidores where s.IdSeguidor = 5
            }
        }

    }
}
