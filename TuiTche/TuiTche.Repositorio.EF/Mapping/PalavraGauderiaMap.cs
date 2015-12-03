using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;

namespace TwiTche.Repositorio.EF.Mapping
{
    class PalavraGauderiaMap : EntityTypeConfiguration<PalavraGauderia>
    {
        public PalavraGauderiaMap()
        {
            ToTable("PalavraGauderia");

            HasKey(p => p.Id);
            Property(p => p.QtdUtilizacao).IsOptional().HasColumnName("QtdUtilizacao");

            HasRequired(p => p.Hashtag).WithMany().HasForeignKey(p => p.IDHashtag);
        }
    }
}
