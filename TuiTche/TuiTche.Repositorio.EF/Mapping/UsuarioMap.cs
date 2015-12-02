using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;

namespace TuiTche.Repositorio.EF.Mapping
{
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
