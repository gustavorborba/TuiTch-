using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuiTche.Dominio;
using TuiTche.WEB.MVC.Models;

namespace TuiTche.WEB.MVC.Mapper
{
    public class PerfilMapper
    {
        public static PerfilModel toModel(Usuario usuario)
        {
            return new PerfilModel()
            {
                IdPerfil = usuario.Id,
                Username = usuario.Username,
                Sexo = usuario.SexoUsuario,
                NomeCompleto = usuario.NomeCompleto,
                Email = usuario.Email,
                Foto = usuario.Foto                
            };
        }
    }
}