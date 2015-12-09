using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Dominio.Interfaces;

namespace TuiTche.DominioTests.Mock
{
    public class CurtirRepositorioMock :ICurtirRepositorio
    {
        IList<Curtir> listaTris = new List<Curtir>();

        public  CurtirRepositorioMock()
        {
            for(int i= 1; i <= 10; i++)
            {
                Curtir curtir1 = new Curtir(i);
                curtir1.IDPublicacao = i;
                curtir1.IDUsuario = i;
                listaTris.Add(curtir1);
            }
        }

        public Curtir FindById(int id)
        {
            return listaTris.Where(p => p.Id == id).FirstOrDefault();
        }

        public int AdicionarCurtir(Curtir curtir)
        {
            listaTris.Add(curtir);
            return 1;
        }

        public Curtir FindByIdUsuarioAdndIdPublicacao(int idUsuario, int idPublicacao)
        {
            return listaTris.Where(c => c.IDUsuario == idUsuario && c.IDPublicacao == idPublicacao).FirstOrDefault();
        }

        public int Remover(Curtir curtir)
        {
            return 1;
        }

        public IList<Curtir> ListarUsuariosCurtiramAPublicacao(int idPublicacao)
        {
            throw new NotImplementedException();
        }
    }
}
