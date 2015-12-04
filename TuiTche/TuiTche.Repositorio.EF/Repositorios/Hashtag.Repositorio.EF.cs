using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Repositorio.EF;

namespace TuiTche.Repositorio.EF
{
    public class HashtagRepositorio
    {
        private BancoDeDados db;

        public Boolean VerificaSeTagEGauderia(String palavra)
        {
            using(db = new BancoDeDados())
            {
                Hashtag hashtag = db.Hashtag.FirstOrDefault(h => h.Palavra == palavra);
                if(db.PalavraGauderia.Where(p => p.IDHashtag == hashtag.Id) != null)
                    return true;

                return false;
            }

        }
    }
}
