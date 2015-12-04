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
            ToTable("Cometario");

            HasKey(c => c.Id);
            Property(p => p.Texto).IsRequired().HasMaxLength(288).HasColumnName("Texto");
            HasRequired(p => p.Usuario).WithMany().Map(c => c.MapKey("IdUsuario"));
            HasRequired(p => p.Publicacao).WithMany().Map(c => c.MapKey("IdPublicacao"));
        }

    
}
}
