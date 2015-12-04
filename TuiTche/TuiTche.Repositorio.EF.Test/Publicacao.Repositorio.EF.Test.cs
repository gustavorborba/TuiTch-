using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Repositorio.EF;

namespace TuiTche.Repositorio.EF.Test
{
    [TestClass]
    public class PublicacaoTest
    {
        [TestMethod]
        public void BuscarPorIdTest()
        {
            PublicacaoRepositorio repositorio = new PublicacaoRepositorio();
           
            Publicacao publicacao = repositorio.BuscarPorPorId(1);

         //   Assert.AreEqual(publicacao.Descricao, "Odin master of the gods");
        }
        [TestMethod]
        public void BuscarPublicacoesDeSeguidores()
        {
            PublicacaoRepositorio repositorio = new PublicacaoRepositorio();
            var teste = repositorio.ListarPublicacoesDeUsuario(4);
           // Assert.AreEqual("aaa222a", teste.FirstOrDefault().Descricao);
        }
    }
}
