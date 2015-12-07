using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuiTche.Dominio;

namespace TuiTche.WEB.MVC.Models
{
    public class PerfilModel
    {
        public int IdPerfil { get; set; }
        public string Username { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public Usuario.Sexo Sexo { get; set; }
        public int NumeroSeguidores { get; set; }
        public int NumeroSeguindo { get; set; }
        public bool Seguindo { get; set; }
    }
}