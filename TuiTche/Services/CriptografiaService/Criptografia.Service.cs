using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio.Services;

namespace Services.CriptografiaService
{
    public class CriptografiaService : IServicoCriptografia
    {
        public string Criptografar(string senha)
        {
            senha += "#$TuiTche_$#@Salt_@$Bagu@l";
            return GerarMd5(senha);
        }
        private string GerarMd5(string texto)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(texto);
            byte[] hash = md5.ComputeHash(inputBytes);
            var sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
