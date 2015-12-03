using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.CriptografiaService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ServicesTest
{
    [TestClass]
    public class CriptografiaTest
    {
        [TestMethod]
        public void GerarSenhaCriptografada()
        {
            CriptografiaService service = new CriptografiaService();
            string hash = service.Criptografar("senha");

            Assert.AreEqual("477F158D66F5A884DC3697E2C97813CE", hash);
        }
    }
}
