using Microsoft.AspNetCore.Mvc;
using EcommerceLicenca.Models;
using System;
using EcommerceLicenca.DAO;

namespace EcommerceLicenca.Controllers
{
    public class PadraoController<T> : Controller where T : PadraoViewModel
    {
        protected PadraoDAO<T> DAO { get; set; }
        protected bool GeraProximoId { get; set; }
        protected string NomeViewIndex { get; set; } = "index";
        protected string NomeViewForm { get; set; } = "form";

        public virtual IActionResult Index()
        {
            try
            {
                var lista = DAO.Listagem();
                return View(NomeViewIndex, lista);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel { Message = erro.ToString() });
            }
        }

        public virtual IActionResult Create()
        {
            try
            {
                ViewBag.Operacao = "I";
                T model = Activator.CreateInstance<T>();
                PreencheDadosParaView("I", model);
                return View(NomeViewForm, model);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel { Message = erro.ToString() });
            }
        }

        protected virtual void PreencheDadosParaView(string operacao, T model)
        {
            if (GeraProximoId && operacao == "I")
            {
                model.Id = DAO.ProximoId();
            }
        }

        public virtual IActionResult Save(T model, string operacao)
        {
            try
            {
                ValidaDados(model, operacao);

                if (!ModelState.IsValid)
                {
                    ViewBag.Operacao = operacao;
                    PreencheDadosParaView(operacao, model);
                    return View(NomeViewForm, model);
                }
                else
                {
                    if (operacao == "I")
                    {
                        DAO.Insert(model);
                    }
                    else
                    {
                        DAO.Update(model);
                    }

                    return RedirectToAction(NomeViewIndex);
                }
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel { Message = erro.ToString() });
            }
        }

        protected virtual void ValidaDados(T model, string operacao)
        {
            ModelState.Clear();

            if (operacao == "I" && DAO.Consulta(model.Id) != null)
            {
                ModelState.AddModelError("Id", "Código já está em uso!");
            }

            if (operacao == "A" && DAO.Consulta(model.Id) == null)
            {
                ModelState.AddModelError("Id", "Este registro não existe!");
            }

            if (model.Id <= 0)
            {
                ModelState.AddModelError("Id", "Id inválido!");
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                ViewBag.Operacao = "A";
                var model = DAO.Consulta(id);

                if (model == null)
                {
                    return RedirectToAction(NomeViewIndex);
                }
                else
                {
                    PreencheDadosParaView("A", model);
                    return View(NomeViewForm, model);
                }
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel { Message = erro.ToString() });
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                DAO.Delete(id);
                return RedirectToAction(NomeViewIndex);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel { Message = erro.ToString() });
            }
        }
    }

}
