using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using TuiTche.Dominio;
using TuiTche.Repositorio.EF.Mapping;

namespace TwiTche.Repositorio.EF
{
    class BancoDeDados : DbContext
    {
        public BancoDeDados()
            : base("TUITCHE")
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Hashtag> Hashtag { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new HashtagMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
