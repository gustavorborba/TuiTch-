using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuiTche.Dominio;
using TuiTche.Dominio.Interfaces;
using TuiTche.Dominio.Services;
using TuiTche.Repositorio.EF;
using TuiTche.Repositorio.EF.Repositorios;
using TuiTche.WEB.MVC.Models;
using TuiTche.WEB.MVC.Seguranca;

namespace TuiTche.WEB.MVC.Controllers
{
    [Authorize]
    public class CurtirController : Controller
    {
        ICurtirRepositorio curtirRepositorio = new CurtirRepositorio();
        IPublicacaoRepositorio publicacaoRepositorio = new PublicacaoRepositorio();
        CurtirService curtirService = new CurtirService(new CurtirRepositorio(), new PontuacaoRepositorio());

        public ActionResult Curtir(int idPublicacao)
        {
            int idUsuario = ControleDeSessao.UsuarioAtual.IdUsuario;
            int idUsuarioPublicacao = publicacaoRepositorio.BuscarPorPorId(idPublicacao).IdUsuario;
            bool curtido = curtirRepositorio.FindByIdUsuarioAdndIdPublicacao(idUsuario, idPublicacao) != null;

            try
            {
                if (curtido == false)
                {
                    curtirService.CurtirPublicacao(idPublicacao, idUsuarioPublicacao, idUsuario);
                    curtido = true;
                }
                else
                {
                    curtirService.DescurtirPublicacao(idPublicacao, idUsuarioPublicacao, idUsuario);
                    curtido = false;
                }
            }
            catch (Exception err)
            {
                ViewBag.mensagem = "Ocorreu um erro na ação tri";
            }

            CurtirModel model = new CurtirModel()
            {
                IdPublicacao = idPublicacao,
                IdUsuario = idUsuario,
                IdUsuarioPublicacao = idUsuarioPublicacao,
                Curtido = curtido,
                Curtidas = curtirRepositorio.ListarUsuariosCurtiramAPublicacao(idPublicacao).Count()
            };

            return PartialView("_Curtir", model);
        }

        public ActionResult CarregarCurtir(int idPublicacao)
        {
            int idUsuario = ControleDeSessao.UsuarioAtual.IdUsuario;
            int idUsuarioPublicacao = publicacaoRepositorio.BuscarPorPorId(idPublicacao).IdUsuario;
            bool curtido = curtirRepositorio.FindByIdUsuarioAdndIdPublicacao(idUsuario, idPublicacao) == null ? false : true;

            CurtirModel model = new CurtirModel()
            {
                IdPublicacao = idPublicacao,
                IdUsuario = idUsuario,
                IdUsuarioPublicacao = idUsuarioPublicacao,
                Curtido = curtido,
                Curtidas = curtirRepositorio.ListarUsuariosCurtiramAPublicacao(idPublicacao).Count()
            };

            return PartialView("_Curtir", model);
        }
    }
}
