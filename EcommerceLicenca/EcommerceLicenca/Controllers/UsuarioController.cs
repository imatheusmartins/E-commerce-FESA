using Microsoft.AspNetCore.Mvc;
using EcommerceLicenca.DAO;
using EcommerceLicenca.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace EcommerceLicenca.Controllers
{
    public class UsuarioController : PadraoController<UsuarioViewModel>
    {
        public UsuarioController()
        {
            DAO = new UsuarioDAO();
            GeraProximoId = true;
        }


        protected override void ValidaDados(UsuarioViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);

            if (string.IsNullOrEmpty(model.NomeUsuario))
                ModelState.AddModelError("NomeUsuario", "Preencha o nome de usuário.");

            if (string.IsNullOrEmpty(model.PerfilUsuario))
                ModelState.AddModelError("PerfilUsuario", "O perfil do usuário deve ser preenchido.");

            if (string.IsNullOrEmpty(model.Cpf) || !Regex.IsMatch(model.Cpf, @"^\d{11}$"))
                ModelState.AddModelError("Cpf", "Preencha um CPF válido com 11 dígitos.");

            if (model.DataNascimento > DateTime.Now)
                ModelState.AddModelError("DataNascimento", "Data de nascimento não pode ser maior que a data atual.");

            if (string.IsNullOrEmpty(model.Email) || !new EmailAddressAttribute().IsValid(model.Email))
                ModelState.AddModelError("Email", "Preencha um e-mail válido.");

            if (string.IsNullOrEmpty(model.Senha))
                ModelState.AddModelError("Senha", "Preencha a senha.");

            if (model.NivelAcesso < 0 || model.NivelAcesso > 1)
                ModelState.AddModelError("NivelAcesso", "O nível de acesso do usuário deve ser 0 ou 1.");
        }



        protected override void PreencheDadosParaView(string Operacao, UsuarioViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
            if (Operacao == "I")
                model.DataNascimento = DateTime.Now;

        }


    }
}
