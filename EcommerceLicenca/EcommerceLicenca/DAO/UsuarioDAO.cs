using EcommerceLicenca.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EcommerceLicenca.DAO
{
    public class UsuarioDAO : PadraoDAO<UsuarioViewModel>
    {
        protected override SqlParameter[] CriaParametros(UsuarioViewModel model)
        {
            SqlParameter[] parametros =
            {
                 new SqlParameter("Id", model.Id),
                 new SqlParameter("Nome", model.NomeUsuario),
                 new SqlParameter("Cpf", model.Cpf),
                 new SqlParameter("DataNascimento", model.DataNascimento),
                 new SqlParameter("Email", model.Email),
                 new SqlParameter("PerfilUsuario", model.PerfilUsuario),
                 new SqlParameter("Senha", model.Senha)
            };
            return parametros;
        }

        protected override UsuarioViewModel MontaModel(DataRow registro)
        {
            UsuarioViewModel u = new UsuarioViewModel()
            {
                Id = Convert.ToInt32(registro["Id"]),
                NomeUsuario = registro["Nome"].ToString(),
                Cpf = registro["Cpf"].ToString(),
                DataNascimento = Convert.ToDateTime(registro["DataNascimento"]),
                Email = registro["Email"].ToString(),
                PerfilUsuario = registro["PerfilUsuario"].ToString(),
                Senha = registro["Senha"].ToString()
            };

            return u;
        }

        public virtual T ConsultaLogin(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id),
                new SqlParameter("tabela", Tabela)
            };
            var tabela = HelperDAO.ExecutaProcSelect("spConsulta", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }

        protected override void SetTabela()
        {
            Tabela = "Usuario";
        }
    }
}
