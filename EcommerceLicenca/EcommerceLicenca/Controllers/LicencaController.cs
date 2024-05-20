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
                ModelState.AddModelError("NomeLicenca", "Preencha o nome da licença.");

            if (string.IsNullOrEmpty(model.RequisitosSistema))
                ModelState.AddModelError("RequisitosSistema", "Preencha os requisitos do sistema.");

            if (model.Valor <= 0)
                ModelState.AddModelError("Valor", "Preencha o valor da licença.");

        }
    }
}
