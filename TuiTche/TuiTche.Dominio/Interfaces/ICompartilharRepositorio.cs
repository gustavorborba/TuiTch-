using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuiTche.Dominio.Interfaces
{
    public interface ICompartilharRepositorio
    {
        Compartilhar BuscarPorId(int id);
        int Compartilhar(Compartilhar publicacao);

    }
}
