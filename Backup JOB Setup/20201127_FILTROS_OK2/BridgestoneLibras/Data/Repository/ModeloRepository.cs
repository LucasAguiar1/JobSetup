using BridgestoneLibras.Data;
using BridgestoneLibras.Data.Repository;
using BridgestoneLibras.ModelsEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LHH.Data.Repository
{
    public class ModeloRepository : SpecRepository<TB_MAQUINA>
    {
        public ModeloRepository(ApplicationDbSpecContext context) : base(context)
        {

        }

        public List<TB_MODELO> Consultar(TB_MODELO pmodelo)
        {
            try
            {
                List<TB_MODELO> lModelos = new List<TB_MODELO>();
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_modelos";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id_maquina", pmodelo.id_maquina));

                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                TB_MODELO tbModelo = new TB_MODELO();
                                tbModelo.id_Modelo = Convert.ToInt32(result["id_Modelo"].ToString());
                                tbModelo.id_maquina = Convert.ToInt32(result["id_maquina"].ToString());
                                tbModelo.nm_modelo = result["nm_modelo"].ToString().Trim();
                                lModelos.Add(tbModelo);
                            }
                        }
                    }
                }

                return lModelos;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

