using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using N1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace N1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Logado = HelperControllers.VerificaUserLogado(HttpContext.Session);
            return View();
        }
    }
}
