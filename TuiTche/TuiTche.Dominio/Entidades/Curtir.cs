using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuiTche.Dominio
{
    public class Curtir : EntidadeBase
    {
        public int IDPublicacao { get; set; }
        public int IDUsuario { get; set; }


        public Publicacao Publicacao{ get; set; }
        public Usuario Usuario { get; set; }

    }
}
