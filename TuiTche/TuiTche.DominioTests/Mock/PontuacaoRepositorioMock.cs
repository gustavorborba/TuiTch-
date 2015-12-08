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
            for(int i = 1; i <= 10; i++)
            {
                Pontuacao pontuacao = new Pontuacao(i);
                pontuacao.PontuacaoTotal = i;
                listaPontos.Add(pontuacao);
            }

         
        }

        public Pontuacao AdicionarPontuacao(Pontuacao pontuacao)
        {
            return null;
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
            return listaPontos.OrderByDescending(p => p.PontuacaoTotal).Skip(posicaoUsuario).FirstOrDefault().PontuacaoTotal;
        }
    }
}
