using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
namespace TwiTche.Repositorio.EF.Mapping
{
    class CompartilharMap : EntityTypeConfiguration<Compartilhar>
    {
        public CompartilharMap()
        {
            ToTable("Compartilhar");

            HasRequired(m => m.Publicacao).WithMany(c => c.Compartilhar).HasForeignKey(m => m.IdPublicacao);
            HasRequired(m => m.Usuario).WithMany(c => c.Compartilhar).HasForeignKey(m => m.IdUsuario).WillCascadeOnDelete(false);
        }
    }
}
