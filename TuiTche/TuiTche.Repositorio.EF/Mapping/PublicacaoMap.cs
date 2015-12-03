using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;

namespace TwiTche.Repositorio.EF.Mapping
{
    class PublicacaoMap : EntityTypeConfiguration<Publicacao>
    {
        public PublicacaoMap()
        {
            ToTable("Publicacao");

            HasKey(m => m.Id);

            Property(m => m.Descricao).IsRequired().HasMaxLength(288).HasColumnName("Descricao");
            Property(m => m.DataPublicacao).IsRequired().HasColumnName("DataPublicacao");
            HasRequired(m => m.UsuarioPublicacao).WithMany().HasForeignKey(m => m.Id);
        }

    }
}
