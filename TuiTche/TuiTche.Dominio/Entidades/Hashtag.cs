using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuiTche.Dominio
{
    public class Hashtag : EntidadeBase
    {
        public String Palavra { get; set; }
        public virtual ICollection<Publicacao> Publicacoes { get; set; }

        public Hashtag()
        {
            Publicacoes = new List<Publicacao>();
        }
    }
}
