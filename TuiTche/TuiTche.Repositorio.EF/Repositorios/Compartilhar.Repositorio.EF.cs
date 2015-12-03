using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Repositorio.EF;

namespace TwiTche.Repositorio.EF
{
    public class CompartilharRepositorio
    {
        BancoDeDados banco;

        public Compartilhar BuscarPorId(int id)
        {   
            using (banco = new BancoDeDados())
            {
                return banco.Compartilhar.Find(id);
            }
        }
    }
}
