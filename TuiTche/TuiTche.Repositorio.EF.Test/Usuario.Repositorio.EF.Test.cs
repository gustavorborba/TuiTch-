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
    public class UsuarioEFTest
    {
        Usuario usuario1 = new Usuario("Usuari1o1")
        {
            NomeCompleto = "Joao",
            Email = "mail@mail.com",
            Senha = "senha",
            SexoUsuario = Usuario.Sexo.MASCULINO,
            Foto = "link"
        };

        Usuario usuario2 = new Usuario("Usuario2")
        {
            NomeCompleto = "Maria",
            Email = "mail2@mail.com",
            Senha = "senha",
            SexoUsuario = Usuario.Sexo.FEMININO,
            Foto = "link"
        };

        Usuario usuario3 = new Usuario("Usuario3")
        {
            NomeCompleto = "Luiza",
            Email = "mail3@mail.com",
            Senha = "senha",
            SexoUsuario = Usuario.Sexo.FEMININO,
            Foto = "link"
        };
        /*
        [TestMethod]
        public void TestarIntegracaoDeUsuarioRelacionamentoDeSeguidores()
        {
            using (var db = new BancoDeDados())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        usuario1.SeguirUsuario(usuario2);
                        usuario3.SeguirUsuario(usuario1);
                        db.Entry(usuario1).State = System.Data.Entity.EntityState.Added;
                        db.Entry(usuario2).State = System.Data.Entity.EntityState.Added;
                        db.Entry(usuario3).State = System.Data.Entity.EntityState.Added;
                        db.SaveChanges();
                        Usuario teste = db.Usuario.Include("Seguidores").Include("Seguindo").FirstOrDefault(u => u.Username == usuario1.Username);


                        foreach (Usuario usuario in teste.Seguindo)
                        {
                            Assert.AreEqual(usuario2.NomeCompleto, usuario.NomeCompleto);
                        }

                        foreach (Usuario usuario in teste.Seguidores)
                        {
                            Assert.AreEqual(usuario3.NomeCompleto, usuario.NomeCompleto);
                        }
                    }
                    finally
                    {
                        dbContextTransaction.Rollback();
                    }                    
                }
            }
        }
        */
    }
}
