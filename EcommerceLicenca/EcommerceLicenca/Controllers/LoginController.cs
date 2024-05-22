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
            UsuarioViewModel user = DAO.ConsultaLogin(email, senha);

            if (user != null && user.NivelAcesso == 0)
            {
                HttpContext.Session.SetString("Cliente", "true");
                return RedirectToAction("index", "Home");
            }
            else if(user != null && user.NivelAcesso == 1)
            {
                HttpContext.Session.SetString("Administrador", "true");
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


