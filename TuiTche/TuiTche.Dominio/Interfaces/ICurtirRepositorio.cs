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
        int AdicionarCurtir(Curtir curtir);
    }
}
