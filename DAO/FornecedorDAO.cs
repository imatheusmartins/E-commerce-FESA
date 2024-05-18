using N1.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace N1.Models
{
    public class FornecedorDAO : PadraoDAO<FornecedorViewModel>
    {
        protected override void SetTabela()
        {
            Tabela = "Fornecedor";
        }

        protected override SqlParameter[] CriaParametros(FornecedorViewModel model)
        {
            return new SqlParameter[]
            {
                new SqlParameter("Id", model.Id),
                new SqlParameter("NomeFornecedor", model.NomeFornecedor),
                new SqlParameter("DataRegistro", model.DataRegistro)
                // Não podemos passar a lista diretamente, ela deve ser tratada separadamente
            };
        }

        protected override FornecedorViewModel MontaModel(DataRow registro)
        {
            var fornecedor = new FornecedorViewModel
            {
                Id = Convert.ToInt32(registro["Id"]),
                NomeFornecedor = registro["NomeFornecedor"].ToString(),
                DataRegistro = Convert.ToDateTime(registro["DataRegistro"]),
                SoftwareDisponiveis = new List<LicencaViewModel>() // Supondo que há outra tabela para Licencas
            };

            // Adicione lógica para preencher SoftwareDisponiveis se necessário

            return fornecedor;
        }

        public List<LicencaViewModel> GetLicencas(int fornecedorId)
        {
            var parametros = new SqlParameter[]
            {
                new SqlParameter("fornecedorId", fornecedorId)
            };

            var tabela = HelperDAO.ExecutaProcSelect("spGetLicencasByFornecedor", parametros);
            var licencas = new List<LicencaViewModel>();

            foreach (DataRow row in tabela.Rows)
            {
                var licenca = new LicencaViewModel
                {
                    Id = Convert.ToInt32(row["id"]),
                    NomeLicenca = row["nomefornecedor"].ToString(),
                    // Preencha outras propriedades conforme necessário
                };

                licencas.Add(licenca);
            }

            return licencas;
        }
    }
}
