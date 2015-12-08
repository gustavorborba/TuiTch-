using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Dominio.Interfaces;
using TuiTche.Repositorio.EF;
using TuiTche.Repositorio.EF.DTO;

namespace TuiTche.Repositorio.EF
{
    public class CompartilharRepositorio : ICompartilharRepositorio
    {
        BancoDeDados banco;

        public Compartilhar BuscarPorId(int id)
        {   
            using (banco = new BancoDeDados())
            {
                return banco.Compartilhar.Include("Usuario").Include("Publicacao").Where(c => c.Id == id).First();
            }
        }

        public Compartilhar Compartilhar(Compartilhar compartilhar)
        {
            using (banco = new BancoDeDados())
            {
                var compartilhamento = banco.Compartilhar.Add(compartilhar);
                banco.SaveChanges();
                return compartilhamento;
            }
        }

        public Compartilhar BuscarCompartilhamento(int IdPublicacao)
        {
            using (banco = new BancoDeDados())
            {
                var compartilhamento = banco.Compartilhar.Include("Usuario").Where(c => c.IdPublicacao == IdPublicacao).OrderByDescending(c => c.DataCompartilhamento).FirstOrDefault();
                return compartilhamento;
            }
        
        }
    }
}
