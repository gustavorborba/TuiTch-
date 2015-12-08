using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuiTche.Dominio.Interfaces
{
    public interface ICurtirRepositorio
    {
        Curtir FindById(int id);
        Curtir FindByIdUsuarioAdndIdPublicacao(int idUsuario, int idPublicacao);
        int AdicionarCurtir(Curtir curtir);
        int Remover(Curtir curtir);
        IList<Curtir> ListarUsuariosCurtiramAPublicacao(int idPublicacao);
    }
}
