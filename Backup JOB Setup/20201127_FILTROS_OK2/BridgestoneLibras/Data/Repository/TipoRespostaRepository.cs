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
    public class TipoRespostaRepository : SpecRepository<TB_TIPORESPOSTA>
    {
        public TipoRespostaRepository(ApplicationDbSpecContext context) : base(context)
        {
        }

        public List<TB_TIPORESPOSTA> Consultar(TB_TIPORESPOSTA tipo)
        {
            try
            {
                List<TB_TIPORESPOSTA> ltipo = new List<TB_TIPORESPOSTA>();
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_TipoResposta";
                    command.CommandType = CommandType.StoredProcedure;
                    if (tipo.id != 0)
                    {
                        command.Parameters.Add(new SqlParameter("@id", tipo.id));
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
                                TB_TIPORESPOSTA r = new TB_TIPORESPOSTA();
                                r.id = Convert.ToInt32(result["id"].ToString());
                                r.tipoResposta = result["tipoResposta"].ToString();


                                ltipo.Add(r);
                            }
                        }
                    }
                }
                return ltipo;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<SelectListItem> Combo(List<TB_TIPORESPOSTA> lTipo, string opcaoInicial)
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

            foreach (var Linha in lTipo)
            {
                lista.Add(new SelectListItem()
                {
                    Value = Linha.id.ToString(),
                    Text = Linha.tipoResposta
                });
            }

            return lista;
        }
    }
}

