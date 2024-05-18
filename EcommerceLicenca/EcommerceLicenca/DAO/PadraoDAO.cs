﻿using EcommerceLicenca.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EcommerceLicenca.DAO
{
    public abstract class PadraoDAO<T> where T : PadraoViewModel
    {
        protected bool ChaveIdentity { get; set; } = false;

        protected PadraoDAO()
        {
            SetTabela();
        }

        protected string Tabela { get; set; }
        protected string NomeSpListagem { get; set; } = "spListagem";

        protected abstract SqlParameter[] CriaParametros(T model);
        protected abstract T MontaModel(DataRow registro);
        protected abstract void SetTabela();

        public virtual void Insert(T model)
        {
            HelperDAO.ExecutaProc("spInsert_" + Tabela, CriaParametros(model));
        }

        public virtual void Update(T model)
        {
            HelperDAO.ExecutaProc("spUpdate_" + Tabela, CriaParametros(model));
        }

        public virtual void Delete(int id)
        {
            var parametros = new SqlParameter[]
            {
            new SqlParameter("id", id),
            new SqlParameter("tabela", Tabela)
            };
            HelperDAO.ExecutaProc("spDelete", parametros);
        }

        public virtual T Consulta(int id)
        {
            var parametros = new SqlParameter[]
            {
            new SqlParameter("id", id),
            new SqlParameter("tabela", Tabela)
            };
            var tabela = HelperDAO.ExecutaProcSelect("spConsulta", parametros);
            if (tabela.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return MontaModel(tabela.Rows[0]);
            }
        }

        public virtual int ProximoId()
        {
            var parametros = new SqlParameter[]
            {
            new SqlParameter("tabela", Tabela)
            };
            var tabela = HelperDAO.ExecutaProcSelect("spProximoId", parametros);
            return Convert.ToInt32(tabela.Rows[0][0]);
        }

        public virtual List<T> Listagem()
        {
            var parametros = new SqlParameter[]
            {
            new SqlParameter("tabela", Tabela),
            new SqlParameter("Ordem", "1") // 1 é o primeiro campo da tabela
            };
            var tabela = HelperDAO.ExecutaProcSelect(NomeSpListagem, parametros);
            var lista = new List<T>();
            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }
            return lista;
        }
    }

}
