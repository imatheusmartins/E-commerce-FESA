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
                 new SqlParameter("NomeUsuario", model.NomeUsuario),
                 new SqlParameter("Cpf", model.Cpf),
                 new SqlParameter("DataNascimento", model.DataNascimento),
                 new SqlParameter("Email", model.Email),
                 new SqlParameter("PerfilUsuario", model.PerfilUsuario),
                 new SqlParameter("Senha", model.Senha),
                 new SqlParameter("NivelAcesso", model.NivelAcesso)
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
                Senha = registro["Senha"].ToString(),
                NivelAcesso = Convert.ToInt32(registro["NivelAcesso"])
            };

            return u;
        }

        public UsuarioViewModel ConsultaLogin(string email, string senha)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("Email", email),
                new SqlParameter("Senha", senha)
            };
            var tabela = HelperDAO.ExecutaProcSelect("spLogin", p);
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
