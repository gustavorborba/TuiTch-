using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TuiTche.WEB.MVC.Mapper;
using TuiTche.WEB.MVC.Models;
using TuiTche.WEB.MVC.Services;

namespace TuiTche.WEB.MVC.Controllers
{
    public class CometarioController : Controller
    {
        ComentarioService service = new ComentarioService();

        [HttpGet]
        public PartialViewResult Comentar()
        {
            return PartialView();
        }

        [HttpPost]
        public void SalvarComentario(ComentarioModel model)
        {
            try
            {
                service.SalvarComentario(ComentarioMapper.ModelToEntity(model));
                ViewBag["mensagem"] = "Comentário realizado com sucesso!";
            }
            catch (Exception)
            {
                ViewBag["mensagem"] = "Ocorreu um erro ao comentar!";
            }
        }
    }
}
