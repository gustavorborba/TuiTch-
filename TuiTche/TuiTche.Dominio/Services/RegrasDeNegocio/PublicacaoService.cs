using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiTche.Dominio;
using TuiTche.Dominio.Interfaces;

namespace TuiTche.Dominio.Services
{
    public class PublicacaoService
    {
        IPublicacaoRepositorio publicacaoRepositorio;

        public PublicacaoService(IPublicacaoRepositorio publicacao)
        {
            this.publicacaoRepositorio = publicacao;
        }

        public IList<Publicacao> GerarTimeLine(int id, int limite)
        {
            IList<Publicacao> publicacoesSeguidores = publicacaoRepositorio.ListarPublicacoesDeSeguidores(id, limite);
            return publicacoesSeguidores.ToList();
        }
    }
}
