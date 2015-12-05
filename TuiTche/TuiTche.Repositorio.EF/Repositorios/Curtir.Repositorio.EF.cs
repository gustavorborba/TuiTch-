using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Repositorio.EF;
using TuiTche.Dominio;

namespace TuiTche.Repositorio.EF.Repositorios
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

        public int CurtirPublicacao(int idPublicacao,int idUsuario)
        {
            using(BancoDeDados db = new BancoDeDados())
            {
                Curtir curtir = new Curtir();
                curtir.IDPublicacao = idPublicacao;
                curtir.IDUsuario = idUsuario;
                db.Curtir.Add(curtir);
                return db.SaveChanges();
            }
        }
    }
}
