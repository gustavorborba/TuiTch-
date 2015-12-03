using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;

namespace TuiTche.Repositorio.EF.Mapping
{
    public class CurtirMap : EntityTypeConfiguration<Curtir>
    {
        public CurtirMap()
        {
            ToTable("Curtir");
            HasKey(h => h.Id);
            Property(h => h.IDPublicacao).IsRequired().HasColumnName("IDPublicacao").HasColumnName("IDPublicacao");
            Property(h => h.IDUsuario).IsRequired().HasColumnName("IDUsuario");


            HasRequired(p => p.Usuario).WithMany().HasForeignKey(p => p.IDUsuario);
            HasRequired(p => p.Publicacao).WithMany().HasForeignKey(p => p.IDPublicacao);

        }

    
}
}
