using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Repositorio.EF;

namespace TwiTche.Repositorio.EF
{
    public class RepositorioUsuario
    {
        public Usuario BuscarPorId(int id)
        {
            using (var db = new BancoDeDados())
            {
                return db.Usuario.Include("Seguidores").Include("Seguindo").FirstOrDefault(u => u.Id == id);
            }
        }
    }
}
