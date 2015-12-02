using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;

namespace TuiTche.Repositorio.EF.Mapping
{
    class HashtagMap : EntityTypeConfiguration<Hashtag>
    {
        public HashtagMap()
        {
            ToTable("Hashtag");
            HasKey(h => h.Id);
            Property(h => h.Palavra).IsRequired().HasColumnName("Palavra");
        }

    }
}
