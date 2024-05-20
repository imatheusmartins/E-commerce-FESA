using EcommerceLicenca.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EcommerceLicenca.DAO
{
    public class PedidoDAO : PadraoDAO<PedidoViewModel>
    {
        protected override SqlParameter[] CriaParametros(PedidoViewModel model)
        {
            SqlParameter[] parametros =
            {
                 new SqlParameter("Id", model.Id),
                 new SqlParameter("IdUsuario", model.IdUsuario),
                 new SqlParameter("ValorPedido", model.ValorPedido),
                 new SqlParameter("StatusPedido", model.StatusPedido),
                 new SqlParameter("DataPedido", model.DataPedido)
            };
            return parametros;
        }

        protected override PedidoViewModel MontaModel(DataRow registro)
        {
            PedidoViewModel p = new PedidoViewModel()
            {
                Id = Convert.ToInt32(registro["Id"]),
                IdUsuario = Convert.ToInt32(registro["IdUsuario"]),
                ValorPedido = Convert.ToDouble(registro["ValorPedido"]),
                StatusPedido = registro["ValorItemPedido"].ToString(),
                DataPedido = Convert.ToDateTime(registro["DataPedido"])
            };

            return p;
        }

        protected override void SetTabela()
        {
            Tabela = "Pedido";
            NomeSpListagem = "spListagem_Pedido";
        }
    }
}
