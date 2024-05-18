using EcommerceLicenca.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EcommerceLicenca.DAO
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
                SoftwareDisponiveis = GetLicencas(Convert.ToInt32(registro["Id"]))
            };

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
                    NomeLicenca = row["NomeLicenca"].ToString(),
                    FornecedorId = Convert.ToInt32(row["FornecedorId"]),
                    ValorMensal = Convert.ToDouble(row["ValorMensal"]),
                    DataInicio = Convert.ToDateTime(row["DataInicio"]),
                    DataValidade = Convert.ToDateTime(row["DataValidade"]),
                    VersaoLicenca = row["VersaoLicenca"].ToString(),
                    TipoLicenca = row["TipoLicenca"].ToString(),
                    Plataforma = row["Plataforma"].ToString(),
                    RequisitosSistema = row["RequisitosSistema"].ToString(),
                    Funcionalidades = row["Funcionalidades"].ToString(),
                    ChaveAtivacao = row["ChaveAtivacao"].ToString()
                };

                licencas.Add(licenca);
            }

            return licencas;
        }

        public void Inserir(FornecedorViewModel fornecedor)
        {
            HelperDAO.ExecutaProc("spIncluiFornecedor", CriaParametros(fornecedor));
        }

        public void Alterar(FornecedorViewModel fornecedor)
        {
            HelperDAO.ExecutaProc("spAlteraFornecedor", CriaParametros(fornecedor));
        }

        public void Excluir(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id)
            };
            HelperDAO.ExecutaProc("spExcluiFornecedor", p);
        }

        public FornecedorViewModel Consulta(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id)
            };
            DataTable tabela = HelperDAO.ExecutaProcSelect("spConsultaFornecedor", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }

        public List<FornecedorViewModel> Listagem()
        {
            List<FornecedorViewModel> lista = new List<FornecedorViewModel>();
            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagemFornecedores", null);
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaModel(registro));
            return lista;
        }

        public int ProximoId()
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("tabela", "Fornecedores")
            };
            DataTable tabela = HelperDAO.ExecutaProcSelect("spProximoId", p);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }
    }
}
