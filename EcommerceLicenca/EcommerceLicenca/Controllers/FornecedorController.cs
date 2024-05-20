using Microsoft.AspNetCore.Mvc;
using EcommerceLicenca.DAO;
using EcommerceLicenca.Models;
using System;
using System.Collections.Generic;

namespace EcommerceLicenca.Controllers
{
    public class FornecedorController : Controller
    {
        //public IActionResult Index()
        //{
        //    try
        //    {
        //        FornecedorDAO dao = new FornecedorDAO();
        //        List<FornecedorViewModel> lista = dao.Listagem();
        //        return View(lista);
        //    }
        //    catch (Exception erro)
        //    {
        //        return View("Error", new ErrorViewModel { Message = erro.ToString() });
        //    }
        //}

        //public IActionResult Create()
        //{
        //    FornecedorViewModel fornecedor = new FornecedorViewModel();
        //    return View("Form", fornecedor);
        //}

        //public IActionResult Salvar(FornecedorViewModel fornecedor)
        //{
        //    try
        //    {
        //        FornecedorDAO dao = new FornecedorDAO();
        //        if (dao.Consulta(fornecedor.Id) == null)
        //            dao.Inserir(fornecedor);
        //        else
        //            dao.Alterar(fornecedor);
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception erro)
        //    {
        //        return View("Error", new ErrorViewModel { Message = erro.ToString() });
        //    }
        //}

        //public IActionResult Edit(int id)
        //{
        //    try
        //    {
        //        FornecedorDAO dao = new FornecedorDAO();
        //        FornecedorViewModel fornecedor = dao.Consulta(id);
        //        if (fornecedor == null)
        //            return RedirectToAction("Index");
        //        else
        //            return View("Form", fornecedor);
        //    }
        //    catch (Exception erro)
        //    {
        //        return View("Error", new ErrorViewModel { Message = erro.ToString() });
        //    }
        //}

        //public IActionResult Delete(int id)
        //{
        //    try
        //    {
        //        FornecedorDAO dao = new FornecedorDAO();
        //        dao.Excluir(id);
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception erro)
        //    {
        //        return View("Error", new ErrorViewModel { Message = erro.ToString() });
        //    }
        //}

        //public IActionResult Detalhes(int id)
        //{
        //    try
        //    {
        //        FornecedorDAO dao = new FornecedorDAO();
        //        FornecedorViewModel fornecedor = dao.Consulta(id);
        //        if (fornecedor == null)
        //            return RedirectToAction("Index");
        //        else
        //            return View(fornecedor);
        //    }
        //    catch (Exception erro)
        //    {
        //        return View("Error", new ErrorViewModel { Message = erro.ToString() });
        //    }
        //}

        //public IActionResult Licencas(int id)
        //{
        //    try
        //    {
        //        FornecedorDAO dao = new FornecedorDAO();
        //        var fornecedor = dao.Consulta(id);
        //        if (fornecedor == null)
        //            return RedirectToAction("Index");

        //        var licencas = dao.GetLicencas(id);
        //        ViewBag.Fornecedor = fornecedor.NomeFornecedor;
        //        return View(licencas);
        //    }
        //    catch (Exception erro)
        //    {
        //        return View("Error", new ErrorViewModel { Message = erro.ToString() });
        //    }
        //}
    }
}
