using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Dominio.Interfaces;

namespace TuiTche.Dominio.Services
{
    public class CurtirService
    {
        private const int PONTOS_POR_TRI = 3;
        ICurtirRepositorio curtirRepositorio;
        IPontuacaoRepositorio pontuacaoRepositorio;
        public CurtirService(ICurtirRepositorio tri, IPontuacaoRepositorio pontuacao)
        {
            this.curtirRepositorio = tri;
            this.pontuacaoRepositorio = pontuacao;
        }

        public Pontuacao CurtirPublicacao(int idPublicacao, int IdPublicacaoUsuario, int idUsuario)
        {
            Pontuacao pontuacao = pontuacaoRepositorio.BuscarPontos(IdPublicacaoUsuario);
            Curtir curtir = new Curtir();
            curtir.IDPublicacao = idPublicacao;
            curtir.IDUsuario = idUsuario;
            curtirRepositorio.AdicionarCurtir(curtir);
            pontuacao.PontuacaoTotal += PONTOS_POR_TRI;
            pontuacaoRepositorio.SomarPontos(pontuacao);
            return pontuacao;
        }

        public Pontuacao DescurtirPublicacao(int idPublicacao, int IdPublicacaoUsuario, int idUsuario)
        {
            Pontuacao pontuacao = pontuacaoRepositorio.BuscarPontos(IdPublicacaoUsuario);
            Curtir curtir = curtirRepositorio.FindByIdUsuarioAdndIdPublicacao(idUsuario, idPublicacao);
            curtirRepositorio.Remover(curtir);
            pontuacao.PontuacaoTotal -= PONTOS_POR_TRI;
            pontuacaoRepositorio.SomarPontos(pontuacao);
            return pontuacao;
        }
    }
}
