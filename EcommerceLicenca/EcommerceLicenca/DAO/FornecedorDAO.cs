using EcommerceLicenca.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EcommerceLicenca.DAO
{
    public class FornecedorDAO : PadraoDAO<FornecedorViewModel>
    {
        protected override SqlParameter[] CriaParametros(FornecedorViewModel model)
        {
            SqlParameter[] parametros =
            {
                 new SqlParameter("Id", model.Id),
                 new SqlParameter("Nome", model.Nome),
                 new SqlParameter("Cnpj", model.Cnpj),
                 new SqlParameter("Email", model.Email)
                 };
            return parametros;
        }

        protected override FornecedorViewModel MontaModel(DataRow registro)
        {
            FornecedorViewModel i = new FornecedorViewModel()
            {
                Id = Convert.ToInt32(registro["Id"]),
                Nome = registro["ChaveAtivacao"].ToString(),
                Cnpj = registro["ChaveAtivacao"].ToString(),
                Email = registro["ChaveAtivacao"].ToString()
                
            };

            return i;
        }

        protected override void SetTabela()
        {
            Tabela = "Fornecedor";
            NomeSpListagem = "spListagemFornecedor";
        }
    }
}
