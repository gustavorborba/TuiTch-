using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Dominio.Services;
using TuiTche.DominioTests.Mock;

namespace TuiTche.DominioTests.ServiceTest
{
    [TestClass]
    public class PublicacaoServiceTest
    {
        [TestMethod]
        public void GerarTimeLineTest()
        {
            PublicacaoService service = new PublicacaoService(new PublicacaoRepositorioMock());
            IList<Publicacao> listaPublicacao = service.GerarTimeLine(1, 1);

            Assert.AreEqual(1, listaPublicacao.Count);
        }
    }
}
