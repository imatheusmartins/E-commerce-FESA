using EcommerceLicenca.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EcommerceLicenca.DAO
{
    public class PedidoItemDAO : PadraoDAO<PedidoItemViewModel>
    {
        public void Inserir(PedidoItemViewModel pedidoItem)
        {
            HelperDAO.ExecutaProc("spIncluiPedidoItem", CriaParametros(pedidoItem));
        }

        public void Alterar(PedidoItemViewModel pedidoItem)
        {
            HelperDAO.ExecutaProc("spAlteraPedidoItem", CriaParametros(pedidoItem));
        }

        public void Excluir(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id)
            };
            HelperDAO.ExecutaProc("spExcluiPedidoItem", p);
        }

        public PedidoItemViewModel Consulta(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id)
            };
            DataTable tabela = HelperDAO.ExecutaProcSelect("spConsultaPedidoItem", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }

        public List<PedidoItemViewModel> Listagem()
        {
            List<PedidoItemViewModel> lista = new List<PedidoItemViewModel>();

            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagemPedidoItens", null);

            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaModel(registro));
            return lista;
        }

        protected override SqlParameter[] CriaParametros(PedidoItemViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("id", model.Id);
            parametros[1] = new SqlParameter("pedidoId", model.PedidoId);
            parametros[2] = new SqlParameter("licencaId", model.LicencaId);
            parametros[3] = new SqlParameter("valorItemPedido", model.ValorItemPedido);
            return parametros;
        }

        protected override PedidoItemViewModel MontaModel(DataRow registro)
        {
            PedidoItemViewModel pedidoItem = new PedidoItemViewModel();
            pedidoItem.Id = Convert.ToInt32(registro["id"]);
            pedidoItem.PedidoId = Convert.ToInt32(registro["pedidoId"]);
            pedidoItem.LicencaId = Convert.ToInt32(registro["licencaId"]);
            pedidoItem.ValorItemPedido = Convert.ToDouble(registro["valorItemPedido"]);
            return pedidoItem;
        }

        protected override void SetTabela()
        {
            Tabela = "PedidoItem"; // Nome da tabela no banco de dados
        }
    }
}
