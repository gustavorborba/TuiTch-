using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Repositorio.EF;
using TwiTche.Repositorio.EF;

namespace TuiTche.Repositorio.EF.Test
{
    [TestClass]
    public class ComentarioEFTest
    {
        Usuario usuario = new Usuario("Usuario-Teste474yhw4")
        {
            NomeCompleto = "Joao",
            Email = "testedhbxfmail@mail.com",
            Senha = "senha",
            SexoUsuario = Usuario.Sexo.MASCULINO,
            Foto = "link"
        };

        Publicacao publiccao = new Publicacao()
        {
            Descricao = "AAAA",
            DataPublicacao = new DateTime(2015, 4, 4),
        };

        Comentario comentario = new Comentario()
        {
            Texto = "Teste"
        };

        [TestMethod]
        public void TestarIntegracaoDeComentario()
        {
            using (var db = new BancoDeDados())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        publiccao.Usuario = usuario;
                        comentario.Usuario = usuario;
                        comentario.Publicacao = publiccao;

                        db.Entry(usuario).State = System.Data.Entity.EntityState.Added;
                        db.Entry(publiccao).State = System.Data.Entity.EntityState.Added;
                        db.Entry(comentario).State = System.Data.Entity.EntityState.Added;
                        db.SaveChanges();

                        Comentario teste = db.Comentario.Where(c => c.Usuario.Username == usuario.Username).FirstOrDefault();

                        Assert.IsTrue(comentario.Texto.Equals(teste.Texto));
                        Assert.AreEqual(comentario.Usuario.NomeCompleto, teste.Usuario.NomeCompleto);
                        Assert.AreEqual(publiccao.Descricao, teste.Publicacao.Descricao);
                    }
                    finally
                    {
                        dbContextTransaction.Rollback();
                    }                    
                }
            }
        }

    }
}
