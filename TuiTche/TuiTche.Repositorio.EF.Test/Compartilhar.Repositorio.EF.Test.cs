using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwiTche.Repositorio.EF;

namespace TuiTche.Repositorio.EF.Test
{
    [TestClass]
    public class Compartilhar
    {
        [TestMethod]
        public void CompartilharBuscarPorId()
        {
            CompartilharRepositorio repositorio = new CompartilharRepositorio();
            var compartilhar = repositorio.BuscarPorId(1);
            Assert.AreEqual(compartilhar.Publicacao.Id, 1);
        }
    }
}
