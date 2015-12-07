using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuiTche.Dominio.Interfaces
{
    public interface IPublicacaoRepositorio
    {
        Publicacao BuscarPorPorId(int id);
        int Criar(Publicacao publicacao);
        int PublicacaoTagInsert(Publicacao publicacao);
        IList<Publicacao> ListarPublicacoesDeSeguidores(int id, int limite);
        IList<Publicacao> BuscarPublicacoesDeUsuario(int id, int limite);
    }
}
