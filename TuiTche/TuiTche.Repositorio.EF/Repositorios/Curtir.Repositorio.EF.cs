using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Repositorio.EF;
using TuiTche.Dominio;
using TuiTche.Dominio.Interfaces;

namespace TuiTche.Repositorio.EF.Repositorios
{
    public class CurtirRepositorio : ICurtirRepositorio
    {
        public Curtir FindById(int id)
        {
            using(BancoDeDados db = new BancoDeDados())
            {
                return db.Curtir.Include("Publicacao").Include("Usuario").Where(c => c.Id == id).FirstOrDefault();
            }
        }

       public int AdicionarCurtir(Curtir curtir)
        {
            using (BancoDeDados db = new BancoDeDados())
            {
                db.Curtir.Add(curtir);

                return db.SaveChanges();
            }
        }
    }
}
