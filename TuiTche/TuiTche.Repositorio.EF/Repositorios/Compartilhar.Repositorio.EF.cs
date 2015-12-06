using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Repositorio.EF;

namespace TuiTche.Repositorio.EF
{
    public class CompartilharRepositorio
    {
        BancoDeDados banco;

        public Compartilhar BuscarPorId(int id)
        {   
            using (banco = new BancoDeDados())
            {
                return banco.Compartilhar.Include("Usuario").Include("Publicacao").Where(c => c.Id == id).First();
            }
        }

        public Compartilhar Compartilhar(Compartilhar publicacao)
        {
            using (banco = new BancoDeDados())
            {
                Compartilhar comp = banco.Compartilhar.Add(publicacao);
                return comp;
            }
        }
        public int AdicionarCompartilhamento(Publicacao publicacao)
        {
            using (banco = new BancoDeDados())
            {
                banco.Entry(publicacao).State = System.Data.Entity.EntityState.Modified;
                return banco.SaveChanges();
            }
        }
    }
}
