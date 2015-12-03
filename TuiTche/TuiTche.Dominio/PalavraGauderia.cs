using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuiTche.Dominio
{
    public class PalavraGauderia : EntidadeBase
    {
        public int IDHashtag { get; set; }

        public Hashtag Hashtag { get; set; }

        public int QtdUtilizacao { get; set; }

    }
}
