using EcommerceLicenca.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EcommerceLicenca.DAO
{
    public class PedidoDAO : PadraoDAO<PedidoViewModel>
    {
        public void Inserir(PedidoViewModel pedido)
        {
            HelperDAO.ExecutaProc("spIncluiPedido", CriaParametros(pedido));
        }

        public void Alterar(PedidoViewModel pedido)
        {
            HelperDAO.ExecutaProc("spAlteraPedido", CriaParametros(pedido));
        }

        public void Excluir(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id)
            };
            HelperDAO.ExecutaProc("spExcluiPedido", p);
        }

        public PedidoViewModel Consulta(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id)
            };
            DataTable tabela = HelperDAO.ExecutaProcSelect("spConsultaPedido", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }

        public List<PedidoViewModel> Listagem()
        {
            List<PedidoViewModel> lista = new List<PedidoViewModel>();

            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagemPedidos", null);

            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaModel(registro));
            return lista;
        }

        protected override SqlParameter[] CriaParametros(PedidoViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("id", model.Id);
            parametros[1] = new SqlParameter("idUsuario", model.IdUsuario);
            parametros[2] = new SqlParameter("valorPedido", model.ValorPedido);
            parametros[3] = new SqlParameter("statusPedido", model.StatusPedido);
            parametros[4] = new SqlParameter("dataPedido", model.DataPedido);
            return parametros;
        }

        protected override PedidoViewModel MontaModel(DataRow registro)
        {
            PedidoViewModel pedido = new PedidoViewModel();
            pedido.Id = Convert.ToInt32(registro["id"]);
            pedido.IdUsuario = Convert.ToInt32(registro["idUsuario"]);
            pedido.ValorPedido = Convert.ToDouble(registro["valorPedido"]);
            pedido.StatusPedido = registro["statusPedido"].ToString();
            pedido.DataPedido = Convert.ToDateTime(registro["dataPedido"]);
            return pedido;
        }

        protected override void SetTabela()
        {
            Tabela = "Pedido"; // Nome da tabela no banco de dados
        }
    }
}
