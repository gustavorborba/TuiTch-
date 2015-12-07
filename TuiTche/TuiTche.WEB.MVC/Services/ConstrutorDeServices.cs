using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuiTche.Dominio.Services;
using TuiTche.Repositorio.EF;
using TuiTche.WEB.MVC.Mapper;
using TuiTche.WEB.MVC.Models;
using TuiTche.WEB.MVC.Seguranca;

namespace TuiTche.WEB.MVC.Services
{
    public class ConstrutorDeServices
    {
        public static ComentarioService ComentarioService = new ComentarioService(new ComentarioRepositorio(), new ComentarioVisualizarModel(), new ComentarioVisualizarMapper());
        public static UsuarioService UsuarioService = new UsuarioService(new PerfilModel(), new PerfilMapper(), new UsuarioRepositorio(), ControleDeSessao.UsuarioAtual.IdUsuario);
    }
}