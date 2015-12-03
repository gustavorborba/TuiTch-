using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Repositorio.EF;

namespace TuiTche.Repositorio.EF.Repositorios
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
