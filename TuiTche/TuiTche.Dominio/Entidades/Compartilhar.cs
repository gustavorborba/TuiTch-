using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuiTche.Dominio
{
    public class Compartilhar : EntidadeBase
    {
        public Publicacao Publicacao { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataCompartilhamento { get; set; }
        public int IdPublicacao { get; set; }
        public int IdUsuario { get; set; }
        public Compartilhar()
        {

        }

        public Compartilhar(int id)
        {
            this.Id = id;
        }
    }
}
