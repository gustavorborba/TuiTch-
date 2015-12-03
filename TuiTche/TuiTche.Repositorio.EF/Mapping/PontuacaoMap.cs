using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
namespace TwiTche.Repositorio.EF.Mapping
{
    class PontuacaoMap : EntityTypeConfiguration<Pontuacao>
    {
        public PontuacaoMap()
        {
            ToTable("Pontuacao");

            HasKey(m => m.Id);

            Property(m => m.PontuacaoTotal).IsRequired().HasColumnName("PontuacaoTotal");
            HasRequired(m => m.UsuarioPontuacao).WithMany().HasForeignKey(m => m.Id);
        }
    }
}
