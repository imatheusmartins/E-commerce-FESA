using EcommerceLicenca.DAO;
using EcommerceLicenca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace EcommerceLicenca.Controllers
{
    public class LoginController : PadraoController<UsuarioViewModel>
    {
        public IActionResult Index()
        {
            return View();

        }
        public IActionResult FazLogin(UsuarioViewModel usuario)
        {
            UsuarioDAO DAO = new UsuarioDAO();
            if (DAO.Consulta(usuario.Id) != null)
            {
                HttpContext.Session.SetString("Logado", "true");
                return RedirectToAction("index", "Home");
            }
            else
            {
                ViewBag.Erro = "Usuário ou senha inválidos!";
                return View("Index");
            }
        }

        public IActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        protected virtual void ValidaDados(T model, string operacao)
        {
            ModelState.Clear();
            if (operacao == "I" && DAO.Consulta(model.Id) != null)
                ModelState.AddModelError("Id", "Código já está em uso!");
            if (operacao == "A" && DAO.Consulta(model.Id) == null)
                ModelState.AddModelError("Id", "Este registro não existe!");
            if (model.Id <= 0)
                ModelState.AddModelError("Id", "Id inválido!");
        }
    }
}


