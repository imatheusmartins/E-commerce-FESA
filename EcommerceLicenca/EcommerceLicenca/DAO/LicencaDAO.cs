using EcommerceLicenca.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EcommerceLicenca.DAO
{
    public class LicencaDAO : PadraoDAO<LicencaViewModel>
    {
        public void Inserir(LicencaViewModel licenca)
        {
            HelperDAO.ExecutaProc("spIncluiLicenca", CriaParametros(licenca));
        }

        public void Alterar(LicencaViewModel licenca)
        {
            HelperDAO.ExecutaProc("spAlteraLicenca", CriaParametros(licenca));
        }

        public void Excluir(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id)
            };
            HelperDAO.ExecutaProc("spExcluiLicenca", p);
        }

        protected override SqlParameter[] CriaParametros(LicencaViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[11];
            parametros[0] = new SqlParameter("id", model.Id);
            parametros[1] = new SqlParameter("nomelicenca", model.NomeLicenca);
            parametros[2] = new SqlParameter("fornecedorid", model.FornecedorId);
            parametros[3] = new SqlParameter("valormensal", model.ValorMensal);
            parametros[4] = new SqlParameter("datainicio", model.DataInicio);
            parametros[5] = new SqlParameter("datavalidade", model.DataValidade);
            parametros[6] = new SqlParameter("versaolicenca", model.VersaoLicenca);
            parametros[7] = new SqlParameter("tipolicenca", model.TipoLicenca);
            parametros[8] = new SqlParameter("plataforma", model.Plataforma);
            parametros[9] = new SqlParameter("requisitossistema", model.RequisitosSistema);
            parametros[10] = new SqlParameter("funcionalidades", model.Funcionalidades);
            return parametros;
        }

        public LicencaViewModel Consulta(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id)
            };
            DataTable tabela = HelperDAO.ExecutaProcSelect("spConsultaLicenca", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }

        public List<LicencaViewModel> Listagem()
        {
            List<LicencaViewModel> lista = new List<LicencaViewModel>();
            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagemLicencas", null);
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaModel(registro));
            return lista;
        }

        public int ProximoId()
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("tabela", "Licencas")
            };
            DataTable tabela = HelperDAO.ExecutaProcSelect("spProximoId", p);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }

        protected override LicencaViewModel MontaModel(DataRow registro)
        {
            LicencaViewModel licenca = new LicencaViewModel();
            licenca.Id = Convert.ToInt32(registro["id"]);
            licenca.NomeLicenca = registro["nomelicenca"].ToString();
            licenca.FornecedorId = Convert.ToInt32(registro["fornecedorid"]);
            licenca.ValorMensal = Convert.ToDouble(registro["valormensal"]);
            licenca.DataInicio = Convert.ToDateTime(registro["datainicio"]);
            licenca.DataValidade = Convert.ToDateTime(registro["datavalidade"]);
            licenca.VersaoLicenca = registro["versaolicenca"].ToString();
            licenca.TipoLicenca = registro["tipolicenca"].ToString();
            licenca.Plataforma = registro["plataforma"].ToString();
            licenca.RequisitosSistema = registro["requisitossistema"].ToString();
            licenca.Funcionalidades = registro["funcionalidades"].ToString();
            licenca.ChaveAtivacao = registro["chaveativacao"].ToString();
            return licenca;
        }

        protected override void SetTabela()
        {
            Tabela = "Licenca"; // Nome da tabela correspondente a Licenca
        }
    }
}
