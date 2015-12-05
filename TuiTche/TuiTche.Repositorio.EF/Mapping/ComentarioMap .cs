using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;

namespace TuiTche.Repositorio.EF.Mapping
{
    public class ComentarioMap : EntityTypeConfiguration<Comentario>
    {
        public ComentarioMap()
        {
            ToTable("Comentario");

            HasKey(c => c.Id);
            Property(p => p.Texto).IsRequired().HasMaxLength(288).HasColumnName("Texto");
            Property(p => p.DataComentario).IsRequired().HasColumnName("DataComentario");
            Property(p => p.IdUsuario).IsRequired().HasColumnName("IdUsuario");
            Property(p => p.IdPublicacao).IsRequired().HasColumnName("IdPublicacao");

            HasRequired(p => p.Usuario).WithMany().HasForeignKey(p => p.IdUsuario);
            HasRequired(p => p.Publicacao).WithMany().HasForeignKey(p => p.IdPublicacao);
        }

    
}
}
