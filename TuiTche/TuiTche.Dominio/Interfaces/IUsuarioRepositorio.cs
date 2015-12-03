using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuiTche.Dominio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        int Salvar(Usuario usuario);
        Usuario BuscarPorId(int id);
        Usuario BuscarPorUsername(string username);
    }
}
