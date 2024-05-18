using N1.Models;
using System.Data;
using System.Data.SqlClient;

namespace N1.DAO
{
    public class PedidoItemDAO : PadraoDAO<PedidoItemViewModel>
    {
        protected override SqlParameter[] CriaParametros(PedidoItemViewModel model)
        {
            SqlParameter[] parametros =
            {
            new SqlParameter("id", model.Id),
            new SqlParameter("PedidoId", model.PedidoId),
            new SqlParameter("LicencaId", model.LicencaId),
            new SqlParameter("Quantidade", model.Quantidade)
        };
            return parametros;
        }

        protected override PedidoItemViewModel MontaModel(DataRow registro)
        {
            PedidoItemViewModel c = new PedidoItemViewModel()
            {
                Id = Convert.ToInt32(registro["id"]),
                LicencaId = Convert.ToInt32(registro["Licencaid"]),
                PedidoId = Convert.ToInt32(registro["PedidoId"]),
                Quantidade = Convert.ToInt32(registro["id"])
            };
            return c;
        }

        protected override void SetTabela()
        {
            Tabela = "PedidoItem";
            ChaveIdentity = true;
        }
    }
}
