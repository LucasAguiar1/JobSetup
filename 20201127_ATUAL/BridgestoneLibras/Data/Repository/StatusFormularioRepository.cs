using BridgestoneLibras.Data;
using BridgestoneLibras.Data.Repository;
using BridgestoneLibras.Models;
using BridgestoneLibras.ModelsEntity;
//using LHH.ModelsEntity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LHH.Data.Repository
{
    public class StatusFormularioRepository : SpecRepository<TB_STATUS_FORMULARIO>
    {
        public StatusFormularioRepository(ApplicationDbSpecContext context) : base(context)
        {
        }

        public List<TB_STATUS_FORMULARIO> Consultar(TB_STATUS_FORMULARIO status)
        {
            try
            {
                List<TB_STATUS_FORMULARIO> lStatus = new List<TB_STATUS_FORMULARIO>();
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_tb_StatusFormulario";
                    command.CommandType = CommandType.StoredProcedure;
                    if (status.id != 0)
                    {
                        command.Parameters.Add(new SqlParameter("@id", status.id));
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("@id", DBNull.Value));
                    }

                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                TB_STATUS_FORMULARIO st = new TB_STATUS_FORMULARIO();
                                st.id = Convert.ToInt32(result["id"].ToString());
                                st.status = result["status"].ToString();
                                st.descricao = result["descricao"].ToString();
                                lStatus.Add(st);
                            }
                        }
                    }
                }
                return lStatus;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<SelectListItem> Combo(List<TB_STATUS_FORMULARIO> lStatus, string opcaoInicial)
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            if (!string.IsNullOrEmpty(opcaoInicial))
            {
                lista.Add(new SelectListItem
                {
                    Text = opcaoInicial,
                    Value = "0"
                });
            }

            foreach (var Linha in lStatus)
            {
                lista.Add(new SelectListItem()
                {
                    Value = Linha.status.ToString(),
                    Text = Linha.descricao
                });
            }

            return lista;
        }
    }
}

