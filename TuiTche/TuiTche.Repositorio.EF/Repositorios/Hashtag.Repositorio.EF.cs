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

        public Hashtag VerificaSeTagEGauderia(String palavra)
        {
            Hashtag hashtag;
            using (db = new BancoDeDados())
            {
                hashtag = db.Hashtag.FirstOrDefault(h => h.Palavra == palavra);
                var hashtagEReservada = db.PalavraGauderia.Where(p => p.IDHashtag == hashtag.Id).ToList().FirstOrDefault();
                if (hashtagEReservada != null)
                {
                    return hashtag;
                }
                return null;
            }
        }

        public int Salvar(Hashtag hashtag)
        {
            using(db = new BancoDeDados())
            {
                db.Entry(hashtag).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public int UpdatePontuacao(int idHashtag)
        {
            using (db = new BancoDeDados())
            {
                PalavraGauderia palavra = db.PalavraGauderia.Where(c => c.IDHashtag == idHashtag).ToList().FirstOrDefault();
                palavra.QtdUtilizacao = palavra.QtdUtilizacao + 1;
                db.Entry(palavra).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
