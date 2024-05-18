using Microsoft.AspNetCore.Mvc;
using EcommerceLicenca.DAO;
using EcommerceLicenca.Models;
using System.Collections.Generic;
using System;

namespace EcommerceLicenca.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            UsuarioDAO dao = new UsuarioDAO();
            List<UsuarioViewModel> lista = dao.Listagem();
            return View(lista);
        }

        public IActionResult Create()
        {
            UsuarioViewModel Usuario = new UsuarioViewModel();
            Usuario.DataNascimento = DateTime.Now;
            return View("Form", Usuario);
        }

        public IActionResult Salvar(UsuarioViewModel Usuario)
        {
            try
            {
                UsuarioDAO dao = new UsuarioDAO();
                if (dao.Consulta(Usuario.Id) == null)
                    dao.Inserir(Usuario);
                else
                    dao.Alterar(Usuario);
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
                UsuarioDAO dao = new UsuarioDAO();
                UsuarioViewModel Usuario = dao.Consulta(id);
                if (Usuario == null)
                    return RedirectToAction("index");
                else
                    return View("Form", Usuario);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

    }
}
