using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;

namespace TuiTche.Repositorio.EF.Mapping
{
    public class HashtagMap : EntityTypeConfiguration<Hashtag>
    {
        public HashtagMap()
        {
            ToTable("Hashtag");
            HasKey(h => h.Id);
            Property(h => h.Palavra).IsRequired().HasColumnName("Palavra");
            HasMany<Publicacao>(s => s.Publicacoes).WithMany(c => c.Hashtags)
                .Map(cs =>
                {
                    cs.MapLeftKey("IdHashtag");
                    cs.MapRightKey("IdPublicacao");
                    cs.ToTable("PublicacaoHashtags");
                });   
        }

    }
}
