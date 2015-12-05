using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuiTche.Dominio;
using TuiTche.Repositorio.EF;

namespace TuiTche.WEB.MVC.Services
{
    public class PublicacaoService
    {
        private PublicacaoRepositorio repositorio = new PublicacaoRepositorio();

        internal Publicacao BuscarPorId(int idPublicacao)
        {
            Publicacao publicacaoDynamic = repositorio.BuscarPorPorId(idPublicacao);
            Publicacao publicacao = new Publicacao(publicacaoDynamic.Id)
            {
                Compartilhar = publicacaoDynamic.Compartilhar,
                DataPublicacao = publicacaoDynamic.DataPublicacao,
                Descricao = publicacaoDynamic.Descricao,
                Hashtags = publicacaoDynamic.Hashtags,
                IdUsuario = publicacaoDynamic.IdUsuario,
                Usuario = null
            };

            return publicacao;
        }
    }
}