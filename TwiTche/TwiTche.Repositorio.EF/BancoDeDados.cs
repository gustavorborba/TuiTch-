using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using TuiTche.Dominio;

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

    class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");

            HasKey(u => u.Id);

            Property(u => u.NomeCompleto).IsRequired().HasMaxLength(128).HasColumnName("Nome_Completo");
            Property(u => u.Username).IsRequired().HasMaxLength(50).HasColumnName("Username");
            Property(u => u.Senha).IsRequired().HasMaxLength(64).HasColumnName("Senha");
            Property(u => u.Email).IsRequired().HasMaxLength(128).HasColumnName("Email");
            Property(u => u.Foto).IsOptional().HasMaxLength(128).HasColumnName("Foto");
            Property(u => u.SexoUsuario).IsRequired().HasColumnName("IdSexoUsuario");
        }
    }
}
