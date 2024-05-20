using Microsoft.AspNetCore.Mvc;
using EcommerceLicenca.DAO;
using EcommerceLicenca.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcommerceLicenca.Controllers
{
    public class UsuarioController : Controller
    {
        //public UsuarioController()
        //{
        //    DAO = new UsuarioDAO();
        //    GeraProximoId = true;
        //}


        //protected override void ValidaDados(AlunoViewModel model, string operacao)
        //{
        //    base.ValidaDados(model, operacao);

        //    if (string.IsNullOrEmpty(model.Nome))
        //        ModelState.AddModelError("Nome", "Preencha o nome.");
        //    if (model.Mensalidade < 0)
        //        ModelState.AddModelError("Mensalidade", "Campo obrigatório.");
        //    if (model.CidadeId <= 0)
        //        ModelState.AddModelError("CidadeId", "Informe o código da cidade.");
        //    if (model.DataNascimento > DateTime.Now)
        //        ModelState.AddModelError("DataNascimento", "Data inválida!");

        //}


        //protected override void PreencheDadosParaView(string Operacao, AlunoViewModel model)
        //{
        //    base.PreencheDadosParaView(Operacao, model);
        //    if (Operacao == "I")
        //        model.DataNascimento = DateTime.Now;

        //    PreparaListaCidadesParaCombo();
        //}

        //private void PreparaListaCidadesParaCombo()
        //{
        //    CidadeDAO cidadeDao = new CidadeDAO();
        //    var cidades = cidadeDao.Listagem();
        //    List<SelectListItem> listaCidades = new List<SelectListItem>();
        //    listaCidades.Add(new SelectListItem("Selecione uma cidade...", "0"));
        //    foreach (var cidade in cidades)
        //    {
        //        SelectListItem item = new SelectListItem(cidade.Nome, cidade.Id.ToString());
        //        listaCidades.Add(item);
        //    }
        //    ViewBag.Cidades = listaCidades;
        //}

    }
}
