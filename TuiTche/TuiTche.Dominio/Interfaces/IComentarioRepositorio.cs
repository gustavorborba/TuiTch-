using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuiTche.Dominio.Interfaces
{
    public interface IComentarioRepositorio
    {
        int Salvar(Comentario Comentario);
        Comentario BuscarPorId(int id);

        IList<Comentario> BuscarListaComIdPublicacao(int idPublicacao);

        IList<Comentario> BuscarProximosComIdPublicacao(int idPublicacao, int? contador = 0);
    }
}
