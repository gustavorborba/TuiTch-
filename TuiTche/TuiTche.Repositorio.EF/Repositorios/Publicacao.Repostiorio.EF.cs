using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;

namespace TuiTche.Repositorio.EF
{
    public class PublicacaoRepositorio
    {
        BancoDeDados banco;

        public Publicacao BuscarPorPorId(int id)
        {
            using (banco = new BancoDeDados())
            {
                 return banco.Publicacao.Find(id);
            }
               
        }
    }
}
