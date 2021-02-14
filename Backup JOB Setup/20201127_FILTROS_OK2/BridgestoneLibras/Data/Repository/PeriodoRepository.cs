using BridgestoneLibras.ModelsEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BridgestoneLibras.Data.Repository
{
    public class PeriodoRepository : Repository<TB_PERIODOS>
    {
        public PeriodoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<TB_PERIODOS> PeriodoConsulta()
        {
            try
            {
                List<TB_PERIODOS> listaPeriodo = new List<TB_PERIODOS>();
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_periodo_consultar";
                    command.CommandType = CommandType.StoredProcedure;

                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                TB_PERIODOS objPeriodo = new TB_PERIODOS();

                                objPeriodo.id_periodo = Convert.ToInt32(result["id_periodo"].ToString());
                                objPeriodo.dt_competencia = Convert.ToDateTime(result["dt_competencia"].ToString());
                                objPeriodo.dt_inicio = Convert.ToDateTime(result["dt_inicio"].ToString());
                                objPeriodo.dt_fim = Convert.ToDateTime(result["dt_fim"].ToString());
                                objPeriodo.nr_dia_bridge = Convert.ToDecimal(result["nr_dia_bridge"].ToString());
                                objPeriodo.vl_peso_ajustado = Convert.ToDecimal(result["vl_peso_ajustado"].ToString());
                                objPeriodo.nm_situacao = result["nm_situacao"].ToString();
                                objPeriodo.id_situacao = Convert.ToInt32(result["id_situacao"].ToString());

                                listaPeriodo.Add(objPeriodo);
                            }
                        }
                        else
                        {
                            return new List<TB_PERIODOS>();
                        }
                    }
                }
                return listaPeriodo;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public TB_PERIODOS PeriodoConsultaPorId(int periodo)
        {
            try
            {
                TB_PERIODOS oPeriodo = new TB_PERIODOS();

                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_periodo_consultar";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@periodo", periodo));

                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                oPeriodo.id_periodo = Convert.ToInt32(result["id_periodo"].ToString());
                                oPeriodo.dt_competencia = Convert.ToDateTime(result["dt_competencia"].ToString());
                                oPeriodo.dt_inicio = Convert.ToDateTime(result["dt_inicio"].ToString());
                                oPeriodo.dt_fim = Convert.ToDateTime(result["dt_fim"].ToString());
                                oPeriodo.nr_dia_bridge = Convert.ToDecimal(result["nr_dia_bridge"].ToString());
                                oPeriodo.vl_peso_ajustado = Convert.ToDecimal(result["vl_peso_ajustado"].ToString());
                                oPeriodo.nm_situacao = result["nm_situacao"].ToString();
                                oPeriodo.id_situacao = Convert.ToInt32(result["id_situacao"].ToString());
                            }
                        }
                    }
                }

                return oPeriodo;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public string PeriodoAltera(int periodo, decimal diasBridge, decimal pesoAjustado, string usuario)
        {
            string mensagem = string.Empty;

            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_periodo_alterar";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@usuario", usuario));
                    command.Parameters.Add(new SqlParameter("@periodo", periodo));
                    command.Parameters.Add(new SqlParameter("@diasBridge", diasBridge));
                    command.Parameters.Add(new SqlParameter("@pesoAjustado", pesoAjustado));
                    command.Parameters.Add(new SqlParameter("@mensagem", mensagem) { Size = 200, Direction = ParameterDirection.Output });

                    Context.Database.OpenConnection();
                    command.ExecuteNonQuery();

                    mensagem = command.Parameters[4].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return mensagem;
        }

        public string PeriodoFechamento(int periodo, string usuario)
        {
            string mensagem = string.Empty;

            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_periodo_fechamento";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@usuario", usuario));
                    command.Parameters.Add(new SqlParameter("@periodo", periodo));
                    command.Parameters.Add(new SqlParameter("@mensagem", mensagem) { Size = 200, Direction = ParameterDirection.Output });

                    Context.Database.OpenConnection();
                    command.ExecuteNonQuery();

                    mensagem = command.Parameters[2].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return mensagem;
        }

        public List<TB_MENSAGENS> PeriodoValidar(int periodo, ref int mensagens)
        {
            mensagens = 0;
            List<TB_MENSAGENS> lValidacao = new List<TB_MENSAGENS>();

            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_fechamento_validar";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@periodo", periodo));
                    command.Parameters.Add(new SqlParameter("@mensagens", mensagens) { Direction = ParameterDirection.Output });

                    Context.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                TB_MENSAGENS oMensagem = new TB_MENSAGENS
                                {
                                    tipo = result["tipo"].ToString(),
                                    mensagem = result["descricao"].ToString()
                                };

                                lValidacao.Add(oMensagem);
                            }
                        }
                    }

                    mensagens = Convert.ToInt16(command.Parameters[1].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return lValidacao;
        }

        public string PeriodoReabrir(int periodo, string usuario)
        {
            string mensagem = string.Empty;

            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_periodo_reabrir";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@usuario", usuario));
                    command.Parameters.Add(new SqlParameter("@periodo", periodo));
                    command.Parameters.Add(new SqlParameter("@mensagem", mensagem) { Size = 200, Direction = ParameterDirection.Output });

                    Context.Database.OpenConnection();
                    command.ExecuteNonQuery();

                    mensagem = command.Parameters[2].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return mensagem;
        }

        public string CalendarioAltera(int calendario, int ignorarDia, string horaInicio, string horaFim, string motivo, string usuario)
        {
            string mensagem = string.Empty;

            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_periodo_calendario_alterar";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@usuario", usuario));
                    command.Parameters.Add(new SqlParameter("@calendario", calendario));
                    command.Parameters.Add(new SqlParameter("@ignorarDia", ignorarDia));
                    command.Parameters.Add(new SqlParameter("@horaInicio", horaInicio));
                    command.Parameters.Add(new SqlParameter("@horaFim", horaFim));
                    command.Parameters.Add(new SqlParameter("@motivo", motivo));
                    command.Parameters.Add(new SqlParameter("@mensagem", mensagem) { Size = 200, Direction = ParameterDirection.Output });

                    Context.Database.OpenConnection();
                    command.ExecuteNonQuery();

                    mensagem = command.Parameters[6].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return mensagem;
        }
    }
}

