using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuiTche.Dominio.Interfaces
{
    public interface IPontuacaoRepositorio
    {
        Pontuacao BuscarPontos(int idUsuario);
        void SomarPontos(Pontuacao pontuacao);
         int NumeroPontuacoesUsuarios();
        int BuscarPontuacaoPorPosicao(int posicaoUsuario);
    }
}
