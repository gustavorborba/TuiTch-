using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Repositorio.EF;
using TuiTche.Dominio;

namespace TwiTche.Repositorio.EF.Repositorios
{
    public class CurtirRepositorio
    {
        public Curtir FindById(int id)
        {
            using(BancoDeDados db = new BancoDeDados())
            {
                return db.Curtir.Include("Publicacao").Include("Usuario").Where(c => c.Id == id).FirstOrDefault();
            }
        }
    }
}
