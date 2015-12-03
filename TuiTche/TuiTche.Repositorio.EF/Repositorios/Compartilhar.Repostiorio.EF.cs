using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Repositorio.EF;

namespace TwiTche.Repositorio.EF.Repositorios
{
    public class CompartilharRepositorio
    {
        BancoDeDados banco;

        public Publicacao ProcurarPorId(int id)
        {
            return banco.Publicacao.Find(id);
        }
    }
}
