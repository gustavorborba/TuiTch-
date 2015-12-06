using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Dominio.Interfaces;

namespace TuiTche.Repositorio.EF.Repositorios
{
    public class PontuacaoRepositorio : IPontuacaoRepositorio
    {
        BancoDeDados banco = new BancoDeDados();

        public Pontuacao BuscarPontos(int idUsuario)
        {
            using (banco = new BancoDeDados())
            {
                return banco.Pontuacao.Find(idUsuario);
            }
        }

        public void SomarPontos(Pontuacao pontuacao)
        {
            using (banco = new BancoDeDados())
            {
                banco.Entry(pontuacao).State = System.Data.Entity.EntityState.Modified;
                banco.SaveChanges();
            }
        }

        public int NumeroPontuacoesUsuarios()
        {
            using (banco = new BancoDeDados())
            {
                return banco.Pontuacao.Count();
            }
        }

        public int BuscarPontuacaoPorPosicao(int posicaoUsuario)
        {
            using (banco = new BancoDeDados())
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT * FROM Pontuacao as p ORDER by PontuacaoTotal desc ");
                query.Append("OFFSET @param ROWS FETCH NEXT 1 ROWS ONLY");
                var pontuacao = banco.Pontuacao.SqlQuery(query.ToString(), new SqlParameter("param", posicaoUsuario)).FirstOrDefault();
                return pontuacao.PontuacaoTotal;
            }

        }
    }
}
