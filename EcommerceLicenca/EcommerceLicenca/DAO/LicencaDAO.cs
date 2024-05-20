using EcommerceLicenca.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EcommerceLicenca.DAO
{
    public class LicencaDAO : PadraoDAO<LicencaViewModel>
    {
        protected override SqlParameter[] CriaParametros(LicencaViewModel model)
        {
            SqlParameter[] parametros =
            {
                 new SqlParameter("Id", model.Id),
                 new SqlParameter("Nome", model.NomeLicenca),
                 new SqlParameter("RequisitosSistema", model.RequisitosSistema),
                 new SqlParameter("Valor", model.Valor)
                 };
            return parametros;
        }

        protected override LicencaViewModel MontaModel(DataRow registro)
        {
            LicencaViewModel l = new LicencaViewModel()
            {
                Id = Convert.ToInt32(registro["Id"]),
                NomeLicenca = registro["Nome"].ToString(),
                RequisitosSistema = registro["RequisitosSistema"].ToString(),
                Valor = Convert.ToInt32(registro["Valor"])
            };

            return l;
        }

        protected override void SetTabela()
        {
            Tabela = "Licenca";
        }
    }
}
