using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio.Interfaces;

namespace TuiTche.Dominio.Services.RegrasDeNegocio
{
    public class UsuarioService
    {
        private const int PONTUACAO_AO_SER_SEGUIDO = 15;
        IUsuarioRepositorio repositorio;
        IPontuacaoRepositorio pontuacaoRepositorio;

        public UsuarioService(IUsuarioRepositorio repositorio, IPontuacaoRepositorio pontuacaoRepositorio)
        {
            this.repositorio = repositorio;
            this.pontuacaoRepositorio = pontuacaoRepositorio;
        }

        public void Seguir(int idSeguidor, int idSeguindo)
        {
            Pontuacao pontuacao = pontuacaoRepositorio.BuscarPontos(idSeguindo);
            pontuacao.PontuacaoTotal += PONTUACAO_AO_SER_SEGUIDO;
            pontuacaoRepositorio.SomarPontos(pontuacao);
            repositorio.Seguir(idSeguidor, idSeguindo);
        }

        public void PararDeSeguir(int idSeguidor, int idSeguindo)
        {
            Pontuacao pontuacao = pontuacaoRepositorio.BuscarPontos(idSeguindo);
            pontuacao.PontuacaoTotal -= PONTUACAO_AO_SER_SEGUIDO;
            pontuacaoRepositorio.SomarPontos(pontuacao);
            repositorio.PararDeSeguir(idSeguidor, idSeguindo);
        }
    }
}
