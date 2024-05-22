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
        public IActionResult Index()
        {
            try
            {
                LicencaDAO dao = new LicencaDAO();
                var listaDeLicencas = dao.Listagem();
                var carrinho = ObtemCarrinhoNaSession();
                //@ViewBag.TotalCarrinho = carrinho.Sum(c => c.Quantidade);
                @ViewBag.TotalCarrinho = 0;
                foreach (var c in carrinho)
                    @ViewBag.TotalCarrinho += c.Quantidade;
                return View(listaDeLicencas);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Detalhes(int LicencaId)
        {
            try
            {
                List<CarrinhoViewModel> carrinho = ObtemCarrinhoNaSession();
                LicencaDAO licDao = new LicencaDAO();
                var modelLicenca = licDao.Consulta(LicencaId);
                CarrinhoViewModel carrinhoModel = carrinho.Find(c => c.LicencaId == LicencaId);
                if (carrinhoModel == null)
                {
                    carrinhoModel = new CarrinhoViewModel();
                    carrinhoModel.LicencaId = LicencaId;
                    carrinhoModel.NomeLicenca = modelLicenca.NomeLicenca;
                    carrinhoModel.Quantidade = 0;
                }
                
                carrinhoModel.ImagemEmBase64 = modelLicenca.ImagemEmBase64;
                return View(carrinhoModel);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        private List<CarrinhoViewModel> ObtemCarrinhoNaSession()
        {
            List<CarrinhoViewModel> carrinho = new List<CarrinhoViewModel>();
            string carrinhoJson = HttpContext.Session.GetString("carrinho");
            if (carrinhoJson != null)
                carrinho = JsonConvert.DeserializeObject<List<CarrinhoViewModel>>(carrinhoJson);
            return carrinho;
        }
        public IActionResult AdicionarCarrinho(int LicencaId, int Quantidade)
        {
            try
            {
                List<CarrinhoViewModel> carrinho = ObtemCarrinhoNaSession();
                CarrinhoViewModel carrinhoModel = carrinho.Find(c => c.LicencaId == LicencaId);
                if (carrinhoModel != null && Quantidade == 0)
                {
                    //tira do carrinho
                    carrinho.Remove(carrinhoModel);
                }
                else if (carrinhoModel == null && Quantidade > 0)
                {
                    //não havia no carrinho, vamos adicionar
                    LicencaDAO LicencaDao = new LicencaDAO();
                    var modelLicenca = LicencaDao.Consulta(LicencaId);
                    carrinhoModel = new CarrinhoViewModel();
                    carrinhoModel.LicencaId = LicencaId;
                    carrinhoModel.NomeLicenca = modelLicenca.NomeLicenca;
                    carrinho.Add(carrinhoModel);
                }
                if (carrinhoModel != null)
                    carrinhoModel.Quantidade = Quantidade;
                string carrinhoJson = JsonConvert.SerializeObject(carrinho);
                HttpContext.Session.SetString("carrinho", carrinhoJson);
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Visualizar()
        {
            try
            {
                LicencaDAO dao = new LicencaDAO();
                var carrinho = ObtemCarrinhoNaSession();
                foreach (var item in carrinho)
                {
                    var lic = dao.Consulta(item.LicencaId);
                    item.ImagemEmBase64 = lic.ImagemEmBase64;
                }
                return View(carrinho);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!HelperControllers.VerificaUserLogado(HttpContext.Session))
            {
                if(!HelperControllers.VerificaAdminLogado(HttpContext.Session))
                    context.Result = RedirectToAction("Index", "Login");
                else
                {
                    ViewBag.Administrador = true;
                    base.OnActionExecuting(context);
                }
            }
            else
            {
                ViewBag.Cliente = true;
                base.OnActionExecuting(context);
            }
        }


        public IActionResult EfetuarPedido()
        {
            try
            {
                using (var transacao = new System.Transactions.TransactionScope())
                {
                    PedidoViewModel pedido = new PedidoViewModel();
                    pedido.DataPedido = DateTime.Now;
                    PedidoDAO pedidoDAO = new PedidoDAO();
                    int idPedido = pedidoDAO.Insert(pedido);
                    PedidoItemDAO itemDAO = new PedidoItemDAO();
                    var carrinho = ObtemCarrinhoNaSession();
                    foreach (var elemento in carrinho)
                    {
                        PedidoItemViewModel item = new PedidoItemViewModel();
                        item.IdPedido = idPedido;
                        item.IdLicenca = elemento.LicencaId;
                        item.Quantidade = elemento.Quantidade;
                        itemDAO.Insert(item);
                    }
                    transacao.Complete();
                }
                HelperControllers.LimparCarrinho(HttpContext.Session);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
    }
}
