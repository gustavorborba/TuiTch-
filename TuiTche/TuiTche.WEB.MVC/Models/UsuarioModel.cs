using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuiTche.WEB.MVC.Models
{
    public class UsuarioModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name ="Nome Completo")]
        [StringLength(128,MinimumLength =5, ErrorMessage ="O Campo deve ter entre 5 e 128 caracteres")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(128, MinimumLength = 5, ErrorMessage = "O Campo deve ter entre 5 e 50 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Campo Obrigatorio")]
        [StringLength(15,MinimumLength =7,ErrorMessage ="O campo deve ter entre 7 e 15 caracteres")]
        public string Senha { get; set; }

        [Display(Name = "Confirmar Senha")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "O campo deve ter entre 7 e 15 caracteres")]
        public string ConfirmarSenha { get; set; }

        [Display(Name ="Endereco de Email")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [EmailAddress(ErrorMessage ="Endereco de Email Inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        public Dominio.Usuario.Sexo Sexo { get; set; }

        [Display(Name = "Foto de Perfil")]
        public HttpPostedFileBase FotoPerfil { get; set; }
    }
}