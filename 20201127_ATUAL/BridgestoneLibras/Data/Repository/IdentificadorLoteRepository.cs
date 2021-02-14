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
    public class IdentificadorLoteRepository : SpecRepository<TB_IDENTIFICADORLOTE>
    {
        public IdentificadorLoteRepository(ApplicationDbSpecContext context) : base(context)
        {

        }

        public TB_IDENTIFICADORLOTE Consultar(TB_IDENTIFICADORLOTE identificacaoLote)
        {
            try
            {
                TB_IDENTIFICADORLOTE tb_identificador = new TB_IDENTIFICADORLOTE();
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_identificador_lote";

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@id_maquina", identificacaoLote.id_maquina));

                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {

                            while (result.Read())
                            {
                                
                                tb_identificador.vc_identificador_lote1 = result["vc_identificador_lote1"].ToString().Trim() ;
                            }
                        }
                    }
                }

                return tb_identificador;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public TB_IDENTIFICADORLOTE Cadastrar(TB_IDENTIFICADORLOTE identificacaoLote)
        {
            try
            {
                TB_IDENTIFICADORLOTE tb_identificador = new TB_IDENTIFICADORLOTE();
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_insert_identificadorLote";

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@idPreenchimento", identificacaoLote.idPreenchimento));
                    command.Parameters.Add(new SqlParameter("@identificadoLote", identificacaoLote.identificadoLote));
                    command.Parameters.Add(new SqlParameter("@idRetorno", identificacaoLote.id) { Size = 200, Direction = ParameterDirection.Output });

                    Context.Database.OpenConnection();
                    command.ExecuteScalar();
                }

                return tb_identificador;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<TB_IDENTIFICADORLOTE> ConsultarIndentificador(TB_IDENTIFICADORLOTE identificacaoLote)
        {
            try
            {
                List<TB_IDENTIFICADORLOTE> list = new List<TB_IDENTIFICADORLOTE>();
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_identificador";

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@idPreenchimento", identificacaoLote.idPreenchimento));

                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {

                            while (result.Read())
                            {
                                TB_IDENTIFICADORLOTE tb_identificador = new TB_IDENTIFICADORLOTE();
                                tb_identificador.idPreenchimento = Convert.ToInt32( result["idPreenchimento"].ToString().Trim());
                                tb_identificador.identificadoLote = result["identificadoLote"].ToString().Trim();
                                tb_identificador.id = Convert.ToInt32( result["id"].ToString().Trim());
                                list.Add(tb_identificador);
                            }
                        }
                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

