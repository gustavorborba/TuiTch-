using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TuiTche.Dominio;
using TwiTche.Repositorio.EF;

namespace TuiTche.DominioTests
{
    [TestClass]
    public class UsuarioTests
    {
        Usuario usuario1 = new Usuario(1, "Usuario")
        {
            NomeCompleto = "Nome",
            Email = "mail@mail.com",
            Senha = "senha",
            SexoUsuario = Usuario.Sexo.MASCULINO,
            Foto = "link"
        };

        [TestMethod]
        public void usuarioEqualsTeste()
        {
            Usuario usuario2 = new Usuario(1, "Usuario")
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
        public void BuscarComSeguidoresESeguindo()
        {
            string espearado = "Id: 1, Username: Usuario, Nome: Nome, Email: mail@mail.com, Senha: senha, Sexo: MASCULINO, Foto: link";

            Assert.AreEqual(espearado, usuario1.ToString());
        }

        [TestMethod]
        public void usuarioToStringTeste()
        {
            RepositorioUsuario repo = new RepositorioUsuario();
            Usuario user = repo.BuscarPorId(1);
            Assert.AreEqual(1, user.Seguidores.Count);
            Assert.AreEqual(3, user.Seguindo.Count);
        }
    }
}
