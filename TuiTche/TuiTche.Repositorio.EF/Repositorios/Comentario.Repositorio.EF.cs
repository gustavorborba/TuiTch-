using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Dominio.Interfaces;
using TuiTche.Repositorio.EF;

namespace TuiTche.Repositorio.EF
{
    public class ComentarioRepositorio : IComentarioRepositorio
    {
        public int Salvar(Comentario comentario)
        {
            using (var db = new BancoDeDados())            
            {                
                db.Comentario.Add(comentario);

                return db.SaveChanges();
            }
        }

        public Comentario BuscarPorId(int id)
        {
            using (var db = new BancoDeDados())
            {
                return db.Comentario.Include("Usuario").Include("Publicacao").FirstOrDefault(u => u.Id == id);
            }
        }

        public IList<Comentario> BuscarListaComIdPublicacao(int idPublicacao)
        {
            using (var db = new BancoDeDados())
            {
                return db.Comentario.Include("Usuario").Where(c => c.IdPublicacao == idPublicacao).OrderBy(c => c.DataComentario).ToList();
            } 
        }

        public IList<Comentario> BuscarProximosComIdPublicacao(int idPublicacao, int? contador)
        {
            if (contador == null) { contador = 2; }
            using (var db = new BancoDeDados())
            {
                return db.Comentario.Include("Usuario").Where(c => c.IdPublicacao == idPublicacao).OrderBy(c => c.DataComentario).Skip((int)contador-2).Take(2).ToList();
            } 
        }
    }
}
