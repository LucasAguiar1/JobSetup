using BridgestoneLibras.Data;
using BridgestoneLibras.Data.Repository;
using BridgestoneLibras.Models;
using BridgestoneLibras.ModelsEntity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LHH.Data.Repository
{
    public class MaquinaPCSRepository : SpecRepository<TB_MAQUINA>
    {
        public MaquinaPCSRepository(ApplicationDbSpecContext context) : base(context)
        {

        }

        public List<TB_MAQUINAPCS> Consultar(TB_MAQUINAPCS pcs)
        {
            try
            {
                List<TB_MAQUINAPCS> lMaquina = new List<TB_MAQUINAPCS>();
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consultaMaquinaPCS";

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@DESCRICAO", pcs.vc_Descripcion.ToString().Trim()));

                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {

                            while (result.Read())
                            {
                                TB_MAQUINAPCS tbMaquina = new TB_MAQUINAPCS();
                                tbMaquina.i_Pk_Maquina = Convert.ToInt32(result["i_Pk_Maquina"].ToString());
                                tbMaquina.vc_Descripcion = result["vc_Descripcion"].ToString().Trim();
                                lMaquina.Add(tbMaquina);
                            }
                        }
                    }
                }

                return lMaquina;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

