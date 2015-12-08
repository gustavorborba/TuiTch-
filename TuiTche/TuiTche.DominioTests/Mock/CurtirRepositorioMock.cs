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
            Curtir curtir1 = new Curtir(1);

            curtir1.IDPublicacao = 1;
            curtir1.IDUsuario = 1;

            listaTris.Add(curtir1); 
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
            throw new NotImplementedException();
        }

        public int Remover(Curtir curtir)
        {
            throw new NotImplementedException();
        }

        public IList<Curtir> ListarUsuariosCurtiramAPublicacao(int idPublicacao)
        {
            throw new NotImplementedException();
        }
    }
}
