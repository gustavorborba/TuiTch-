using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuiTche.Dominio
{
    public class Publicacao : EntidadeBase
    {
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }
        public virtual ICollection<Hashtag> Hashtags { get; set; }

        public ICollection<Compartilhar> Compartilhar { get; set; }

        public Publicacao()
        {
            Hashtags = new List<Hashtag>();
        }
        public Publicacao(int id) : this()
        {
            this.Id = id;
        }

    }
}
