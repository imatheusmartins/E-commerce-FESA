using Microsoft.AspNetCore.Mvc;
using EcommerceLicenca.DAO;
using EcommerceLicenca.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;


namespace EcommerceLicenca.Controllers
{
    public class LicencaController : PadraoController<LicencaViewModel>
    {
        public LicencaController()
        {
            DAO = new LicencaDAO();
            GeraProximoId = true;
        }

        protected override void ValidaDados(LicencaViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);
            if (string.IsNullOrEmpty(model.NomeLicenca))
                ModelState.AddModelError("Nome", "Preencha o nome da licença.");

            if (string.IsNullOrEmpty(model.RequisitosSistema))
                ModelState.AddModelError("Nome", "Preencha os requisitos do sistema.");

            if (model.Valor <= 0)
                ModelState.AddModelError("Nome", "Preencha o valor da licença.");

        }
    }
}
