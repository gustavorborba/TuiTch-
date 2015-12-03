using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuiTche.Dominio.Services
{
    public interface IServicoCriptografia
    {
        string Criptografar(string senha);
    }
}
