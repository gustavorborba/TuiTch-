using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuiTche.Dominio
{
    public class Publicacao : EntidadeBase
    {
        public string Descricao { get; private set; }
        public DateTime DataPublicacao { get; private set; }

        public Publicacao()
        {
             
        }
        public Publicacao(string descricao, DateTime data)
        {
            this.Descricao = descricao;
            this.DataPublicacao = data;
        }

    }
}
