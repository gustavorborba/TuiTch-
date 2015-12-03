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

            HasKey(m => m.Id);

            HasRequired(m => m.Publicacao).WithMany(p => p.Compartilhar).HasForeignKey(m => m.IdPublicacao);
            HasRequired(m => m.Usuario).WithMany(u => u.Compartilhar).HasForeignKey(m => m.IdUsuario).WillCascadeOnDelete(false);
        }
    }
}
