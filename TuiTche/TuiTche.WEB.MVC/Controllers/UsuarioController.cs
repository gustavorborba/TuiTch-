﻿using Services.CriptografiaService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TuiTche.Dominio;
using TuiTche.Repositorio.EF;
using TuiTche.WEB.MVC.Models;
using TuiTche.WEB.MVC.Services;

namespace TuiTche.WEB.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioRepositorio repositorio = new UsuarioRepositorio();
        UsuarioService usuarioService = new UsuarioService();
        CriptografiaService criptografia = new CriptografiaService();
        // GET: Usuario
        public ActionResult index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View("CadastrarUsuario");
        }
        [HttpGet]
        public ActionResult perfil(string username)
        {
            PerfilModel model = usuarioService.BuscarPorUsername(username);
            return View(model);
        }

        public ActionResult CadastrarUsuario(UsuarioModel model)
        {
            bool usuarioRepetido = repositorio.VerificarEmailEUsernameRepetido(model.Email, model.Username);

            if (!usuarioRepetido)
            {
                TempData["Mensagem"] = "Usuário e/ou Email já se encontram na base de dados";
                return View("CadastrarUsuario", model);
            }

            bool senhasCoincidem = criptografia.SenhasIdenticas(model.Senha, model.ConfirmarSenha);
            bool senhasEmBranco = model.Senha != null && model.ConfirmarSenha != null;
            if (!senhasCoincidem && senhasEmBranco)
            {
                TempData["Mensagem"] = "Senhas não coincidem";
                return View("CadastrarUsuario", model);
            }

            if (ModelState.IsValid)
            {
                string file = Path.GetFileName(model.FotoPerfil.FileName);
                string local = Path.Combine(Server.MapPath("~/Content/img-upload/"), model.Username + file);
                model.FotoPerfil.SaveAs(local);
                Usuario usuario = new Usuario(model.Username)
                {
                    NomeCompleto = model.NomeCompleto,
                    Senha = criptografia.Criptografar(model.Senha),
                    Email = model.Email,
                    SexoUsuario = model.Sexo,
                    Foto = local
                };

                repositorio.CadastrarUsuario(usuario);
                TempData["Mensagem"] = "Usuario Cadastrado com Sucesso!";
                return RedirectToAction("Index", "Login");
            }
            TempData["Mensagem"] = "Ocorreu os seguintes erros: ";
            return View("CadastrarUsuario", model);
        }
    }
}