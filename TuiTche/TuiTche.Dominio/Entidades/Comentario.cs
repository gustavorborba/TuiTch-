using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuiTche.Dominio
{
    public class Comentario : EntidadeBase
    {
        public int IdPublicacao { get; set; }
        public Publicacao Publicacao { get; set; }
        public string Texto { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataComentario { get; set; }

        public Comentario()
        {

        }
    }
}
