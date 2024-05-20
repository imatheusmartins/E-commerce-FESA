using EcommerceLicenca.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EcommerceLicenca.DAO
{
    public class ItemLicencaDAO : PadraoDAO<ItemLicencaViewModel>
    {
        protected override SqlParameter[] CriaParametros(ItemLicencaViewModel model)
        {
            SqlParameter[] parametros =
            {
                 new SqlParameter("Id", model.Id),
                 new SqlParameter("IdLicenca", model.IdLicenca),
                 new SqlParameter("ChaveAtivacao", model.ChaveAtivacao)
                 };
            return parametros;
        }

        protected override ItemLicencaViewModel MontaModel(DataRow registro)
        {
            ItemLicencaViewModel i = new ItemLicencaViewModel()
            {
                Id = Convert.ToInt32(registro["Id"]),
                IdLicenca = Convert.ToInt32(registro["IdLicenca"]),
                ChaveAtivacao = registro["ChaveAtivacao"].ToString()
            };

            return i;
        }

        protected override void SetTabela()
        {
            Tabela = "ItemLicenca";
            NomeSpListagem = "spListagemItemLicenca";
        }
    }
}
