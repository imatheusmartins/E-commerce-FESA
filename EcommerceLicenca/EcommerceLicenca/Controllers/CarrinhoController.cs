using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using N1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace N1.Controllers
{
    public class CarrinhoController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                CidadeDAO dao = new CidadeDAO();
                var listaDeCidades = dao.Listagem();
                var carrinho = ObtemCarrinhoNaSession();

                ViewBag.TotalCarrinho = carrinho.Sum(c => c.Quantidade);

                return View(listaDeCidades);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel { Message = erro.ToString() });
            }
        }

        public IActionResult Detalhes(int idCidade)
        {
            try
            {
                var carrinho = ObtemCarrinhoNaSession();
                CidadeDAO cidDao = new CidadeDAO();
                var modelCidade = cidDao.Consulta(idCidade);
                var carrinhoModel = carrinho.FirstOrDefault(c => c.CidadeId == idCidade);

                if (carrinhoModel == null)
                {
                    carrinhoModel = new CarrinhoViewModel
                    {
                        CidadeId = idCidade,
                        Nome = modelCidade.Nome,
                        Quantidade = 0
                    };
                }

                carrinhoModel.ImagemEmBase64 = modelCidade.ImagemEmBase64;

                return View(carrinhoModel);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel { Message = erro.ToString() });
            }
        }

        private List<CarrinhoViewModel> ObtemCarrinhoNaSession()
        {
            var carrinho = new List<CarrinhoViewModel>();
            string carrinhoJson = HttpContext.Session.GetString("carrinho");

            if (!string.IsNullOrEmpty(carrinhoJson))
            {
                carrinho = JsonConvert.DeserializeObject<List<CarrinhoViewModel>>(carrinhoJson);
            }

            return carrinho;
        }

        public IActionResult AdicionarCarrinho(int CidadeId, int Quantidade)
        {
            try
            {
                var carrinho = ObtemCarrinhoNaSession();
                var carrinhoModel = carrinho.FirstOrDefault(c => c.CidadeId == CidadeId);

                if (carrinhoModel != null && Quantidade == 0)
                {
                    // Remove do carrinho
                    carrinho.Remove(carrinhoModel);
                }
                else if (carrinhoModel == null && Quantidade > 0)
                {
                    // Adiciona ao carrinho
                    CidadeDAO cidDao = new CidadeDAO();
                    var modelCidade = cidDao.Consulta(CidadeId);
                    carrinhoModel = new CarrinhoViewModel
                    {
                        CidadeId = CidadeId,
                        Nome = modelCidade.Nome
                    };
                    carrinho.Add(carrinhoModel);
                }

                if (carrinhoModel != null)
                {
                    carrinhoModel.Quantidade = Quantidade;
                }

                string carrinhoJson = JsonConvert.SerializeObject(carrinho);
                HttpContext.Session.SetString("carrinho", carrinhoJson);

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel { Message = erro.ToString() });
            }
        }

        public IActionResult Visualizar()
        {
            try
            {
                CidadeDAO dao = new CidadeDAO();
                var carrinho = ObtemCarrinhoNaSession();

                foreach (var item in carrinho)
                {
                    var cid = dao.Consulta(item.CidadeId);
                    item.ImagemEmBase64 = cid.ImagemEmBase64;
                }

                return View(carrinho);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel { Message = erro.ToString() });
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!HelperControllers.VerificaUserLogado(HttpContext.Session))
            {
                context.Result = RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.Logado = true;
                base.OnActionExecuting(context);
            }
        }
    }
}
