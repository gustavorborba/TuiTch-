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

        public Curtir FindByIdUsuarioAdndIdPublicacao(int idUsuario, int idPublicacao)
        {
            using (BancoDeDados db = new BancoDeDados())
            {
                return db.Curtir.Include("Publicacao").Include("Usuario").Where(c => c.IDUsuario == idUsuario && c.IDPublicacao == idPublicacao).FirstOrDefault();
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

        public int Remover(Curtir curtir)
        {
            using (BancoDeDados db = new BancoDeDados())
            {
                db.Entry(curtir).State = System.Data.Entity.EntityState.Deleted;

                return db.SaveChanges();
            }
        }

        public IList<Curtir> ListarUsuariosCurtiramAPublicacao(int idPublicacao)
        {
            using (BancoDeDados db = new BancoDeDados())
            {
                return db.Curtir.Include("Usuario").Where(c => c.IDPublicacao == idPublicacao).ToList();
            }
        }
    }
}
