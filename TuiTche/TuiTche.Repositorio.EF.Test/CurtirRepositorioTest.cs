using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Repositorio.EF.Repositorios;

namespace TuiTche.Repositorio.EF.Test
{
    [TestClass]
    public class CurtirRepositorioTest
    {
        [TestMethod]
        public void TestarBuscarUmaCurtida()
        {
            CurtirRepositorio rep = new CurtirRepositorio();
            Curtir c = rep.FindById(1);
            Assert.AreEqual("Oden", c.Usuario.NomeCompleto);
            Assert.AreEqual(1, c.Publicacao.Id);
        }
    }
}
