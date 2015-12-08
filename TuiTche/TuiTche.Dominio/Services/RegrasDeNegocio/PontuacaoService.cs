using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Dominio.Interfaces;

namespace TuiTche.Dominio.Services
{
    public class PontuacaoService
    {
        private IPontuacaoRepositorio repositorioPontuacao;
        public PontuacaoService(IPontuacaoRepositorio repositorio)
        {
            this.repositorioPontuacao = repositorio;
        }

        public Ranking BuscarRankingUsuario(int idUsuario)
        {
            var usuario = repositorioPontuacao.BuscarPontos(idUsuario);
            if(usuario == null)
            {
                Pontuacao pontuacao = new Pontuacao();
                pontuacao.PontuacaoTotal = 0;
                pontuacao.Usuario = new Usuario(idUsuario);
                usuario = repositorioPontuacao.AdicionarPontuacao(pontuacao);
            }
            return VerificarRanking(usuario);
        }

        private Ranking VerificarRanking(Pontuacao usuario)
        {
            const double PRIMEIRORANKING = 0.1;
            const double SEGUNDORANKING = 0.2;
            const double TERCEIRORANKING = 0.4;
            const double QUARTORANKING = 0.8;
            const int correcaoPosicaoInicial = 1;
            var totalUsuarios = repositorioPontuacao.NumeroPontuacoesUsuarios();
            int primeiraPosicaoRanking = 0;
            //valor de correcao causado por List iniciarem em posicao 0, fazendo com que a primeira posicao seja sempre um valor abaixo

            bool totalUsuarioEBaixoNaoPrecisaCompensar = primeiraPosicaoRanking < 10;
            if (totalUsuarioEBaixoNaoPrecisaCompensar)
            {
                primeiraPosicaoRanking = 0;
            }
            else
            {
                primeiraPosicaoRanking = Convert.ToInt32(totalUsuarios * PRIMEIRORANKING) - correcaoPosicaoInicial;
            }    

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
            int pontuacaoUltimoPatrao = repositorioPontuacao.BuscarPontuacaoPorPosicao(posicaoRanking);
            bool usuarioAtualEPatrao = pontuacaoUltimoPatrao <= pontosUsuarioAtual;
            if (usuarioAtualEPatrao)
            {
                return true;
            }
            return false;
        }
    }
}
