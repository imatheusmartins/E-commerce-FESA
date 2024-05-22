using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using EcommerceLicenca.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceLicenca.DAO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlTypes;

namespace EcommerceLicenca.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult ExibeConsultaAvancadaPedidos()
        {
            try
            {
                return View("ConsultaAvancadaPedido");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.Message));
            }
        }

        public IActionResult ObtemDadosConsultaAvancada(
                             string nome,
                             int codigoPedido,
                             DateTime dataInicial,
                             DateTime dataFinal)
        {
            try
            {
                PedidoItemDAO dao = new PedidoItemDAO();
                if (string.IsNullOrEmpty(nome))
                    nome = "";
                if (dataInicial.Date == Convert.ToDateTime("01/01/0001"))
                    dataInicial = SqlDateTime.MinValue.Value;
                if (dataFinal.Date == Convert.ToDateTime("01/01/0001"))
                    dataFinal = SqlDateTime.MaxValue.Value;
                var lista = dao.ConsultaAvancadaPedidos(nome, codigoPedido, dataInicial, dataFinal);
                return PartialView("pvGridPedido", lista);
            }
            catch (Exception erro)
            {
                return Json(new { erro = true, msg = erro.Message });
            }
        }
    }
}
