using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TuiTche.Dominio;

namespace TuiTche.Repositorio.EF.Test
{
    [TestClass]
    public class Hashtag
    {
        [TestMethod]
        public void VerificaSeTagGauderiaRetorna()
        {
            HashtagRepositorio rep = new HashtagRepositorio();
            // Assert.AreEqual(true, rep.VerificaSeTagEGauderia("Patrão"));
            PublicacaoRepositorio prep = new PublicacaoRepositorio();
            //IList<Publicacao> publicacao = prep.BuscarPublicacoes("Tche");
            //Assert.IsNotNull(publicacao);

        }
    }
}
