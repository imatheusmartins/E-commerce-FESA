using EcommerceLicenca.DAO;
using EcommerceLicenca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace EcommerceLicenca.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }
        public IActionResult FazLogin(string email, string senha)
        {
            UsuarioDAO DAO = new UsuarioDAO();
            if (DAO.ConsultaLogin(email, senha) != null)
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
    }
}


