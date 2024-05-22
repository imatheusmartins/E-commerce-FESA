using EcommerceLicenca.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EcommerceLicenca.DAO
{
    public class PedidoItemDAO : PadraoDAO<PedidoItemViewModel>
    {
        protected override SqlParameter[] CriaParametros(PedidoItemViewModel model)
        {
            SqlParameter[] parametros =
            {
                 new SqlParameter("Id", model.Id),
                 new SqlParameter("IdLicenca", model.IdLicenca),
                 new SqlParameter("IdPedido", model.IdPedido),
                 new SqlParameter("Quantidade", model.Quantidade)
            };
            return parametros;
        }

        protected override PedidoItemViewModel MontaModel(DataRow registro)
        {
            PedidoItemViewModel r = new PedidoItemViewModel()
            {
                Id = Convert.ToInt32(registro["Id"]),
                IdLicenca = Convert.ToInt32(registro["IdLicenca"]),
                IdPedido = Convert.ToInt32(registro["IdPedido"]),
                Quantidade = Convert.ToInt32(registro["Quantidade"])
            };

            return r;
        }

        protected override void SetTabela()
        {
            Tabela = "ItemPedido";
        }

        public List<PedidoItemViewModel> ConsultaAvancadaPedidos(string nome,
                                 int codigoPedido,
                                 DateTime dataInicial,
                                 DateTime dataFinal)
        {
            SqlParameter[] p = {
                         new SqlParameter("nome", nome),
                         new SqlParameter("IdPedido", codigoPedido),
                         new SqlParameter("dataInicial", dataInicial),
                         new SqlParameter("dataFinal", dataFinal),
                         };
            var tabela = HelperDAO.ExecutaProcSelect("spConsultaAvancadaPedidos", p);
            var lista = new List<PedidoItemViewModel>();
            foreach (DataRow dr in tabela.Rows)
                lista.Add(MontaModel(dr));
            return lista;
        }
    }
}
