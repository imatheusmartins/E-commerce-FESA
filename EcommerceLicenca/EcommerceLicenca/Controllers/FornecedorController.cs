using Microsoft.AspNetCore.Mvc;
using EcommerceLicenca.DAO;
using EcommerceLicenca.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EcommerceLicenca.Controllers
{
    public class FornecedorController : PadraoController<FornecedorViewModel>
    {
        public FornecedorController()
        {
            DAO = new FornecedorDAO();
            GeraProximoId = true;
        }


        protected override void ValidaDados(FornecedorViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);

            if (string.IsNullOrEmpty(model.Nome))
                ModelState.AddModelError("Nome", "Preencha o nome do fornecedor.");

            if (string.IsNullOrEmpty(model.Cnpj) || !Regex.IsMatch(model.Cnpj, @"^\d{14}$"))
                ModelState.AddModelError("Cnpj", "Preencha um CNPJ válido com 14 dígitos.");

            if (string.IsNullOrEmpty(model.Email) || !new EmailAddressAttribute().IsValid(model.Email))
                ModelState.AddModelError("Email", "Preencha um e-mail válido.");
        }


        protected override void PreencheDadosParaView(string Operacao, FornecedorViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);

        }
    }
}
