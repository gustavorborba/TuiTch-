using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Dominio.Interfaces;

namespace TuiTche.DominioTests.Mock
{
    public class PublicacaoRepositorioMock : IPublicacaoRepositorio
    {
        IList<Publicacao> listaPublicacao = new List<Publicacao>();
        public PublicacaoRepositorioMock()
        {
            for(int i = 1; i<= 10; i++)
            {
                Publicacao publicacao = new Publicacao(i);
                publicacao.DataPublicacao = DateTime.Now;
                publicacao.Descricao = "a" + i;
                publicacao.IdUsuario = i;
                listaPublicacao.Add(publicacao);
            }
        }

        public Publicacao BuscarPorPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Publicacao> BuscarPublicacoesDeUsuario(int id, int limite)
        {
            return listaPublicacao.Where(p => p.IdUsuario == id).Take(limite).ToList();
        }

        public Publicacao Criar(Publicacao publicacao)
        {
            throw new NotImplementedException();
        }

        public IList<Publicacao> ListarPublicacoesDeSeguidores(int id, int limite)
        {
            return listaPublicacao.Where(p => p.IdUsuario == id).Take(limite).ToList();
        }

        public int PublicacaoTagInsert(Publicacao publicacao)
        {
            throw new NotImplementedException();
        }
    }
}
