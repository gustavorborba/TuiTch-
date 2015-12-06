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
                hashtag = db.Hashtag.Include("Publicacoes").FirstOrDefault(h => h.Palavra == palavra);
                if(hashtag != null) {
                    var hashtagEReservada = db.PalavraGauderia.Where(p => p.IDHashtag == hashtag.Id).ToList().FirstOrDefault();
                    if (hashtagEReservada != null)
                    {
                        return hashtag;
                    }
                    }
                return null;
            }
        }

        public List<Hashtag> PalavrasMaisUsadas()
        {
            var gauderias = new List<PalavraGauderia>();
            using (db = new BancoDeDados())
            {
                gauderias = db.PalavraGauderia.SqlQuery("select top 10 * from PalavraGauderia order by  QtdUtilizacao desc;").ToList();
            }
            return ParaHashtag(gauderias);
        }

        private List<Hashtag> ParaHashtag(List<PalavraGauderia> gauderias)
        {
            List < Hashtag > hashtags= new List<Hashtag>();
            using(db = new BancoDeDados())
            {
                foreach(var p in gauderias)
                {
                    hashtags.Add(db.Hashtag.FirstOrDefault(h => h.Id == p.IDHashtag));
                }
                return hashtags;
            }
        }

        public Hashtag Criar(String hashtag)
        {
            using(db = new BancoDeDados())
            {
                Hashtag tag = db.Hashtag.Add(new Hashtag() { Palavra = hashtag });
                db.SaveChanges();
                return tag;
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

        public IList<Hashtag> BuscarTodos()
        {
            using (var db = new BancoDeDados())
            {
                return db.Hashtag.Where(u => u.Palavra != null).ToList();
            }
        }

        public IList<Hashtag> BuscarPorPalavra(string term)
        {
            using (var db = new BancoDeDados())
            {
                return db.Hashtag.Where(t => t.Palavra.Contains(term)).ToList();
            }
        }
    }
}
