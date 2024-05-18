using EcommerceLicenca.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EcommerceLicenca.DAO
{
    public class UsuarioDAO : PadraoDAO<UsuarioViewModel>
    {
        public void Inserir(UsuarioViewModel Usuario)
        {
            HelperDAO.ExecutaProc("spIncluiUsuario", CriaParametros(Usuario));
        }
        public void Alterar(UsuarioViewModel Usuario)
        {
            HelperDAO.ExecutaProc("spAlteraUsuario", CriaParametros(Usuario));
        }
        public void Excluir(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id)
            };
            HelperDAO.ExecutaProc("spExcluiUsuario", p);
        }

        protected override SqlParameter[] CriaParametros(UsuarioViewModel model)
        {
            SqlParameter[] parametros = new SqlParameter[14];
            parametros[0] = new SqlParameter("id", model.Id);
            parametros[1] = new SqlParameter("nomeusuario", model.NomeUsuario);
            parametros[2] = new SqlParameter("cpf", model.Cpf);
            parametros[3] = new SqlParameter("datanascimento", model.DataNascimento);
            parametros[4] = new SqlParameter("email", model.Email);
            parametros[5] = new SqlParameter("senha", model.Senha);
            parametros[6] = new SqlParameter("tipousuario", model.TipoUsuario);
            return parametros;
        }

        public UsuarioViewModel Consulta(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id)
            };
            DataTable tabela = HelperDAO.ExecutaProcSelect("spConsultaUsuario", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }
        public List<UsuarioViewModel> Listagem()
        {
            List<UsuarioViewModel> lista = new List<UsuarioViewModel>();

            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagemUsuarios", null);
            
        foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaModel(registro));
            return lista;
        }
        public int ProximoId()
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("tabela", "Usuarios")
            };
            DataTable tabela = HelperDAO.ExecutaProcSelect("spProximoId", p);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }


        protected override UsuarioViewModel MontaModel(DataRow registro)
        {
            UsuarioViewModel usuario = new UsuarioViewModel();
            usuario.Id = Convert.ToInt32(registro["id"]);
            usuario.NomeUsuario = registro["nomeusuario"].ToString();
            usuario.Cpf = registro["cpf"].ToString();
            usuario.DataNascimento = Convert.ToDateTime(registro["datanascimento"]);
            usuario.Email = registro["email"].ToString();
            usuario.Senha = registro["senha"].ToString();
            usuario.TipoUsuario = (bool)registro["tipousuario"];
            return usuario;
        }

        protected override void SetTabela()
        {
            Tabela = "Usuario"; // Altere o nome da tabela para Usuario
        }
    }
}
