using BridgestoneLibras.Data;
using BridgestoneLibras.Data.Repository;
using BridgestoneLibras.Models;
using BridgestoneLibras.ModelsEntity;
using LHH.ModelsEntity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LHH.Data.Repository
{
    public class StatusRepository : SpecRepository<TB_STATUS>
    {
        public StatusRepository(ApplicationDbSpecContext context) : base(context)
        {
        }

        public List<TB_STATUS> Consultar(TB_STATUS status)
        {
            try
            {
                List<TB_STATUS> lStatus = new List<TB_STATUS>();
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_status";
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
                                TB_STATUS st = new TB_STATUS();
                                st.id = Convert.ToInt32(result["id"].ToString());
                                st.status = result["status"].ToString();
                               

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
        public List<SelectListItem> Combo(List<TB_STATUS> lStatus, string opcaoInicial)
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
                    Value = Linha.id.ToString(),
                    Text = Linha.status
                });
            }

            return lista;
        }
    }
}

