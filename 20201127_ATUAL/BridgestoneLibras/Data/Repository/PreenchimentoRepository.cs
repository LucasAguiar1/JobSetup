using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using BridgestoneLibras.Data;
using BridgestoneLibras.Data.Repository;
using BridgestoneLibras.Models;
using BridgestoneLibras.ModelsEntity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LHH.Data.Repository
{
    public class PreenchimentoRepository : SpecRepository<TB_FILHO>
    {
        public PreenchimentoRepository(ApplicationDbSpecContext context) : base(context)
        {
        }
        

        public TB_PREENCHIMENTO Cadastrar(TB_PREENCHIMENTO preenchimento)
        {
            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_insert_Preenchimento";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@id_formulario", preenchimento.id_formulario));
                    command.Parameters.Add(new SqlParameter("@idRetorno", preenchimento.idPreenchimento) { Size = 200, Direction = ParameterDirection.Output });

                    Context.Database.OpenConnection();
                    command.ExecuteScalar();

                    if (Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value) != 0)
                    {
                        preenchimento.idPreenchimento = Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value);
                    }
                }

                return preenchimento;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
