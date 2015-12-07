using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Dominio.Interfaces;

namespace TuiTche.DominioTests.Mock
{
    public class PontuacaoRepositorioMock : IPontuacaoRepositorio
    {
        IList<Pontuacao> listaPontos = new List<Pontuacao>();

        public PontuacaoRepositorioMock()
        {
            Pontuacao pontuacao = new Pontuacao(1);

            pontuacao.PontuacaoTotal = 0;
            listaPontos.Add(pontuacao);
        }

        public void SomarPontos(Pontuacao pontuacao)
        {
            
        }

        public Pontuacao BuscarPontos(int id)
        {
            return listaPontos.Where(p => p.Id == id).FirstOrDefault();
        }
        public int NumeroPontuacoesUsuarios()
        {
            return listaPontos.Count;
        }

        public int BuscarPontuacaoPorPosicao(int posicaoUsuario)
        {
            return listaPontos.Skip(posicaoUsuario).FirstOrDefault().PontuacaoTotal;
        }
    }
}
