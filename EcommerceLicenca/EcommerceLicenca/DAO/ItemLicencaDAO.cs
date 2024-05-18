using EcommerceLicenca.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EcommerceLicenca.DAO
{
    public class ItemLicencaDAO : PadraoDAO<ItemLicencaViewModel>
    {
        public void Inserir(ItemLicencaViewModel item)
        {
            HelperDAO.ExecutaProc("spIncluiItemLicenca", CriaParametros(item));
        }

        public void Alterar(ItemLicencaViewModel item)
        {
            HelperDAO.ExecutaProc("spAlteraItemLicenca", CriaParametros(item));
        }

        public void Excluir(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id)
            };
            HelperDAO.ExecutaProc("spExcluiItemLicenca", p);
        }

        public ItemLicencaViewModel Consulta(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id)
            };
            DataTable tabela = HelperDAO.ExecutaProcSelect("spConsultaItemLicenca", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }

        public List<ItemLicencaViewModel> Listagem()
        {
            List<ItemLicencaViewModel> lista = new List<ItemLicencaViewModel>();

            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagemItensLicenca", null);

            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaModel(registro));
            return lista;
        }

        protected override SqlParameter[] CriaParametros(ItemLicencaViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("id", model.Id);
            parametros[1] = new SqlParameter("idLicenca", model.IdLicenca);
            parametros[2] = new SqlParameter("fornecedorId", model.FornecedorId);
            parametros[3] = new SqlParameter("chaveAtivacao", model.ChaveAtivacao);
            parametros[4] = new SqlParameter("valorItemLicenca", model.ValorItemLicenca);
            return parametros;
        }

        protected override ItemLicencaViewModel MontaModel(DataRow registro)
        {
            ItemLicencaViewModel item = new ItemLicencaViewModel();
            item.Id = Convert.ToInt32(registro["id"]);
            item.IdLicenca = Convert.ToInt32(registro["idLicenca"]);
            item.FornecedorId = Convert.ToInt32(registro["fornecedorId"]);
            item.ChaveAtivacao = registro["chaveAtivacao"].ToString();
            item.ValorItemLicenca = Convert.ToDouble(registro["valorItemLicenca"]);
            return item;
        }

        protected override void SetTabela()
        {
            Tabela = "ItemLicenca"; // Nome da tabela no banco de dados
        }
    }
}
