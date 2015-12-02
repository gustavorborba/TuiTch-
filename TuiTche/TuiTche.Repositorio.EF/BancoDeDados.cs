using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using TuiTche.Dominio;
using TwiTche.Repositorio.EF.Mapping;

namespace TwiTche.Repositorio.EF
{
    class BancoDeDados : DbContext
    {
        public BancoDeDados()
            : base("TUITCHE")
        {

        }

        public DbSet<Usuario> Usuario { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
        }
    }    
}
