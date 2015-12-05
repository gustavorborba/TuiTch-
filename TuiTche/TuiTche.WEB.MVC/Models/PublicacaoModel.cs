using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuiTche.Dominio;

namespace TuiTche.WEB.MVC.Models
{
    public class PublicacaoModel
    {
        public int IdPublicacao { get; set; }
        public string Mensagem { get; set; }
        public string NomeUsuario { get; set; }
        public int IdUsuario { get; set; }

        public PublicacaoModel(Publicacao publicacao)
        {
            this.IdPublicacao = publicacao.Id;
            this.Mensagem = publicacao.Descricao;
            this.IdUsuario = publicacao.IdUsuario;
            this.NomeUsuario = publicacao.Usuario.NomeCompleto;
        }
    }
}