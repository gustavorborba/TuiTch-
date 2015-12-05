using System;
using System.Collections.Generic;
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

        public void SomarPontos(Pontuacao pontuacao, int pontos )
        {
            pontuacao.PontuacaoTotal += pontos;
            using (banco = new BancoDeDados())
            {
                banco.Entry(pontuacao).State = System.Data.Entity.EntityState.Modified;
                banco.SaveChanges();
            }
        }
    }
}
