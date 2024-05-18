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
            parametros[4] = new SqlParameter("sexo", model.Sexo);
            parametros[5] = new SqlParameter("rua", model.Rua);
            parametros[6] = new SqlParameter("numero", model.Numero);
            parametros[7] = new SqlParameter("bairro", model.Bairro);
            parametros[8] = new SqlParameter("cep", model.Cep);
            parametros[9] = new SqlParameter("telefonecelular", model.TelefoneCelular);
            parametros[10] = new SqlParameter("email", model.Email);
            parametros[11] = new SqlParameter("senha", model.Senha);
            parametros[12] = new SqlParameter("dataregistro", model.DataRegistro);
            parametros[13] = new SqlParameter("tipousuario", model.TipoUsuario);
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
            usuario.Sexo = registro["sexo"].ToString();
            usuario.Rua = registro["rua"].ToString();
            usuario.Numero = registro["numero"].ToString();
            usuario.Bairro = registro["bairro"].ToString();
            usuario.Cep = registro["cep"].ToString();
            usuario.TelefoneCelular = registro["telefonecelular"].ToString();
            usuario.Email = registro["email"].ToString();
            usuario.Senha = registro["senha"].ToString();
            usuario.TipoUsuario = (bool)registro["tipousuario"];
            usuario.DataRegistro = Convert.ToDateTime(registro["dataregistro"]);
            return usuario;
        }

        protected override void SetTabela()
        {
            Tabela = "Usuario"; // Altere o nome da tabela para Usuario
        }
    }
}
