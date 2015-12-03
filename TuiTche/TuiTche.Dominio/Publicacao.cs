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

        public ICollection<Compartilhar> Compartilhar { get; set; }

        public Publicacao()
        {
             
        }
        public Publicacao(int id)
        {
            this.Id = id;
        }

    }
}
