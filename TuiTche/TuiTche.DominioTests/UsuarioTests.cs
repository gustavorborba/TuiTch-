using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TuiTche.Dominio;
using TwiTche.Repositorio.EF;
using TuiTche.Repositorio.EF;

namespace TuiTche.DominioTests
{
    [TestClass]
    public class UsuarioTests
    {
        Usuario usuario1 = new Usuario("Usuario", 1)
        {
            NomeCompleto = "Nome",
            Email = "mail@mail.com",
            Senha = "senha",
            SexoUsuario = Usuario.Sexo.MASCULINO,
            Foto = "link"
        };

        [TestMethod]
        public void UsuarioEqualsTeste()
        {
            Usuario usuario2 = new Usuario("Usuario", 1)
            {
                NomeCompleto = "Nome",
                Email = "mail@mail.com",
                Senha = "senha",
                SexoUsuario = Usuario.Sexo.MASCULINO,
                Foto = "link"
            };

            Assert.AreEqual(usuario1, usuario2);
        }

        [TestMethod]
        public void UsuarioSegueUsuario2()
        {
            Usuario usuario2 = new Usuario("Usuario2")
            {
                NomeCompleto = "João",
                Email = "mail@mail.com",
                Senha = "senha",
                SexoUsuario = Usuario.Sexo.MASCULINO,
                Foto = "link"
            };

            usuario1.SeguirUsuario(usuario2);
            foreach (Usuario usuario in usuario1.Seguindo) {
                Assert.AreEqual(usuario2, usuario);
            }
            
        }

        [TestMethod]
        public void UsuarioToStringTeste()
        {
            string espearado = "Id: 1, Username: Usuario, Nome: Nome, Email: mail@mail.com, Senha: senha, Sexo: MASCULINO, Foto: link";

            Assert.AreEqual(espearado, usuario1.ToString());
        }
    }
}
