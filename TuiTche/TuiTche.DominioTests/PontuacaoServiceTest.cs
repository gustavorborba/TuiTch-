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
    public class PontuacaoServiceTest
    {
        PontuacaoService service = new PontuacaoService(new PontuacaoRepositorioMock());

        [TestMethod]
        public void BuscarRankingPiaTest()
        {

            Ranking ranking = service.BuscarRankingUsuario(1);

            Assert.AreEqual(ranking, Ranking.PIA);
        }

        [TestMethod]
        public void BuscarRankingPiaNext()
        {
            Ranking ranking = service.BuscarRankingUsuario(2);

            Assert.AreEqual(ranking, Ranking.PIA);
        }
        [TestMethod]
        public void BuscarRankingGauderio()
        {
            Ranking ranking = service.BuscarRankingUsuario(3);

            Assert.AreEqual(ranking, Ranking.GAUDERIO);
        }

        [TestMethod]
        public void BuscarRankingGauderioNext()
        {
            Ranking ranking = service.BuscarRankingUsuario(4);

            Assert.AreEqual(ranking, Ranking.GAUDERIO);
        }

        [TestMethod]
        public void BuscarRankingXiru()
        {
            Ranking ranking = service.BuscarRankingUsuario(7);

            Assert.AreEqual(ranking, Ranking.XIRU);
        }

        [TestMethod]
        public void BuscarRankingXiruNext()
        {
            Ranking ranking = service.BuscarRankingUsuario(8);

            Assert.AreEqual(ranking, Ranking.XIRU);
        }

        [TestMethod]
        public void BuscarRankingGaloVeio()
        {

            Ranking ranking = service.BuscarRankingUsuario(9);

            Assert.AreEqual(ranking, Ranking.GALO_VEIO);
        }

        [TestMethod]
        public void BuscarRankingPatrao()
        {

            Ranking ranking = service.BuscarRankingUsuario(10);

            Assert.AreEqual(ranking, Ranking.PATRAO);
        }

    }
}
