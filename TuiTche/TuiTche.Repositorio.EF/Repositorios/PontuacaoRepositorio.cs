using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;

namespace TuiTche.Repositorio.EF.Repositorios
{
    public class PontuacaoRepositorio
    {
        BancoDeDados banco = new BancoDeDados();

        public Pontuacao BuscarPontos(int idUsuario)
        {
            using (banco = new BancoDeDados())
            {
                return banco.Pontuacao.Find(idUsuario);
            }
        }

        public void SomarPontos(Pontuacao pontuacao, int pontos)
        {
            pontuacao.PontuacaoTotal += pontos;
            using (banco = new BancoDeDados())
            {
                banco.Entry(pontuacao).State = System.Data.Entity.EntityState.Modified;
                banco.SaveChanges();
            }
        }

        private int NumeroPontuacoesUsuarios()
        {
            using (banco = new BancoDeDados())
            {
                return banco.Pontuacao.Count();
            }
        }

        private int BuscarPontuacaoPorPosicao(int posicaoUsuario)
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

        public Ranking BuscarRankingUsuario(int idUsuario)
        {
            var usuario = BuscarPontos(idUsuario);
            return VerificarRanking(usuario);
        }

        private Ranking VerificarRanking(Pontuacao usuario)
        {
            const double PRIMEIRORANKING = 0.1;
            const double SEGUNDORANKING = 0.2;
            const double TERCEIRORANKING = 0.4;
            const double QUARTORANKING = 0.8;
            const int correcaoPosicaoInicial = 1;
            var totalUsuarios = this.NumeroPontuacoesUsuarios();

            int primeiraPosicaoRanking = Convert.ToInt32(totalUsuarios * PRIMEIRORANKING) - correcaoPosicaoInicial;

            bool isPatrao = validarRanking(usuario.PontuacaoTotal, primeiraPosicaoRanking);
            if (isPatrao)
            {
                return Ranking.PATRAO;
            }

            int segundaPosicaoRanking = Convert.ToInt32(totalUsuarios * SEGUNDORANKING) - correcaoPosicaoInicial;

            bool isGaloVeio = validarRanking(usuario.PontuacaoTotal, segundaPosicaoRanking);
            if (isGaloVeio)
            {
                return Ranking.GALO_VEIO;
            }

            int terceiraPosicaoRanking = Convert.ToInt32(totalUsuarios * TERCEIRORANKING) - correcaoPosicaoInicial;

            bool isXiru = validarRanking(usuario.PontuacaoTotal, terceiraPosicaoRanking);
            if (isXiru)
            {
                return Ranking.XIRU;
            }

            int quartaPosicaoRanking = Convert.ToInt32(totalUsuarios * QUARTORANKING) - correcaoPosicaoInicial;

            bool isGauderio = validarRanking(usuario.PontuacaoTotal, quartaPosicaoRanking);
            if (isGauderio)
            {
                return Ranking.GAUDERIO;
            }
            return Ranking.PIA;
        }

        private bool validarRanking(int pontosUsuarioAtual, int posicaoRanking)
        {
            int pontuacaoUltimoPatrao = this.BuscarPontuacaoPorPosicao(posicaoRanking);
            bool usuarioAtualEPatrao = pontuacaoUltimoPatrao <= pontosUsuarioAtual;
            if (usuarioAtualEPatrao)
            {
                return true;
            }
            return false;
        }
    }
}
