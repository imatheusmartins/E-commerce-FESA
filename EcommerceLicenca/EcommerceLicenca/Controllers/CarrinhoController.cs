using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using EcommerceLicenca.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceLicenca.DAO;

namespace EcommerceLicenca.Controllers
{
    public class CarrinhoController : Controller
    {
        //public IActionResult Index()
        //{
        //    try
        //    {
        //        LicencaDAO dao = new LicencaDAO();
        //        var listaDeLicencas = dao.Listagem();
        //        var carrinho = ObtemCarrinhoNaSession();

        //        ViewBag.TotalCarrinho = carrinho.Sum(c => c.Quantidade);

        //        return View(listaDeLicencas);
        //    }
        //    catch (Exception erro)
        //    {
        //        return View("Error", new ErrorViewModel { Message = erro.ToString() });
        //    }
        //}

        //public IActionResult Detalhes(int idLicenca)
        //{
        //    try
        //    {
        //        var carrinho = ObtemCarrinhoNaSession();
        //        LicencaDAO licDao = new LicencaDAO();
        //        var modelLicenca = licDao.Consulta(idLicenca);
        //        var carrinhoModel = carrinho.FirstOrDefault(c => c.LicencaId == idLicenca);

        //        if (carrinhoModel == null)
        //        {
        //            carrinhoModel = new CarrinhoViewModel
        //            {
        //                LicencaId = idLicenca,
        //                NomeLicenca = modelLicenca.NomeLicenca,
        //                Quantidade = 0
        //            };
        //        }

        //        return View(carrinhoModel);
        //    }
        //    catch (Exception erro)
        //    {
        //        return View("Error", new ErrorViewModel { Message = erro.ToString() });
        //    }
        //}

        //private List<CarrinhoViewModel> ObtemCarrinhoNaSession()
        //{
        //    var carrinho = new List<CarrinhoViewModel>();
        //    string carrinhoJson = HttpContext.Session.GetString("carrinho");

        //    if (!string.IsNullOrEmpty(carrinhoJson))
        //    {
        //        carrinho = JsonConvert.DeserializeObject<List<CarrinhoViewModel>>(carrinhoJson);
        //    }

        //    return carrinho;
        //}

        //public IActionResult AdicionarCarrinho(int LicencaId, int Quantidade)
        //{
        //    try
        //    {
        //        var carrinho = ObtemCarrinhoNaSession();
        //        var carrinhoModel = carrinho.FirstOrDefault(c => c.LicencaId == LicencaId);

        //        if (carrinhoModel != null && Quantidade == 0)
        //        {
        //            // Remove do carrinho
        //            carrinho.Remove(carrinhoModel);
        //        }
        //        else if (carrinhoModel == null && Quantidade > 0)
        //        {
        //            // Adiciona ao carrinho
        //            LicencaDAO licDao = new LicencaDAO();
        //            var modelLicenca = licDao.Consulta(LicencaId);
        //            carrinhoModel = new CarrinhoViewModel
        //            {
        //                LicencaId = LicencaId,
        //                NomeLicenca = modelLicenca.NomeLicenca
        //            };
        //            carrinho.Add(carrinhoModel);
        //        }

        //        if (carrinhoModel != null)
        //        {
        //            carrinhoModel.Quantidade = Quantidade;
        //        }

        //        string carrinhoJson = JsonConvert.SerializeObject(carrinho);
        //        HttpContext.Session.SetString("carrinho", carrinhoJson);

        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception erro)
        //    {
        //        return View("Error", new ErrorViewModel { Message = erro.ToString() });
        //    }
        //}

        //public IActionResult Visualizar()
        //{
        //    try
        //    {
        //        LicencaDAO dao = new LicencaDAO();
        //        var carrinho = ObtemCarrinhoNaSession();

        //        foreach (var item in carrinho)
        //        {
        //            var lic = dao.Consulta(item.LicencaId);
        //            // Adicione outras propriedades necessárias da licença ao item
        //            item.NomeLicenca = lic.NomeLicenca;
        //        }

        //        return View(carrinho);
        //    }
        //    catch (Exception erro)
        //    {
        //        return View("Error", new ErrorViewModel { Message = erro.ToString() });
        //    }
        //}

        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    if (!HelperControllers.VerificaUserLogado(HttpContext.Session))
        //    {
        //        context.Result = RedirectToAction("Index", "Login");
        //    }
        //    else
        //    {
        //        ViewBag.Logado = true;
        //        base.OnActionExecuting(context);
        //    }
        //}
    }
}
