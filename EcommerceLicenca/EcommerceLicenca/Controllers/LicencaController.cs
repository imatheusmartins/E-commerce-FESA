using Microsoft.AspNetCore.Mvc;
using EcommerceLicenca.DAO;
using EcommerceLicenca.Models;
using System.Collections.Generic;
using System;

namespace EcommerceLicenca.Controllers
{
    public class LicencaController : Controller
    {
        public IActionResult Index()
        {
            LicencaDAO dao = new LicencaDAO();
            List<LicencaViewModel> lista = dao.Listagem();
            return View(lista);
        }

        public IActionResult Create()
        {
            LicencaViewModel licenca = new LicencaViewModel();
            licenca.DataInicio = DateTime.Now;
            licenca.DataValidade = DateTime.Now.AddYears(1);
            return View("Form", licenca);
        }

        public IActionResult Salvar(LicencaViewModel licenca)
        {
            try
            {
                LicencaDAO dao = new LicencaDAO();
                if (dao.Consulta(licenca.Id) == null)
                    dao.Inserir(licenca);
                else
                    dao.Alterar(licenca);
                return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                LicencaDAO dao = new LicencaDAO();
                LicencaViewModel licenca = dao.Consulta(id);
                if (licenca == null)
                    return RedirectToAction("index");
                else
                    return View("Form", licenca);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
    }
}
