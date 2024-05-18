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
            parametros[2] = new SqlParameter("valor", model.Valor);
            parametros[3] = new SqlParameter("requisitossistema", model.RequisitosSistema);
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
            licenca.Valor= Convert.ToDouble(registro["valor"]);
            licenca.RequisitosSistema = registro["requisitossistema"].ToString();
            return licenca;
        }

        protected override void SetTabela()
        {
            Tabela = "Licenca"; // Nome da tabela correspondente a Licenca
        }
    }
}
