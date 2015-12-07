using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Dominio.Services;
using TuiTche.DominioTests.Mock;

namespace TuiTche.DominioTests
{
    [TestClass]
    public class CurtirServiceTest
    {
        [TestMethod]
        public void CurtirPublicacaoTest()
        {
            CurtirService service = new CurtirService(new CurtirRepositorioMock(),new PontuacaoRepositorioMock());

            Pontuacao pontuacao = service.CurtirPublicacao(1, 1, 1);

            // 1 a mais devido a mock iniciar com 1 ponto
            Assert.AreEqual(4, pontuacao.PontuacaoTotal);
        }
    }
}
