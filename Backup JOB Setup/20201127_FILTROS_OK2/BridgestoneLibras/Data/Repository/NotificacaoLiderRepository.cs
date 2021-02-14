using BridgestoneLibras.Data;
using BridgestoneLibras.Data.Repository;
using BridgestoneLibras.Models;
using BridgestoneLibras.ModelsEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LHH.Data.Repository
{
    public class NotificacaoLiderRepository : SpecRepository<TB_NOTIFICACAOLIDER>
    {
        public NotificacaoLiderRepository(ApplicationDbSpecContext context) : base(context)
        {

        }

        public List<TB_NOTIFICACAOLIDER> Consultar(TB_NOTIFICACAOLIDER model)
        {
            try
            {
                List<TB_NOTIFICACAOLIDER> lModelos = new List<TB_NOTIFICACAOLIDER>();
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_notificacaolider";
                    command.CommandType = CommandType.StoredProcedure;

                    if(model.id_notificacao == 0)
                        command.Parameters.Add(new SqlParameter("@id_notificacaolider", DBNull.Value));
                    else
                        command.Parameters.Add(new SqlParameter("@id_notificacaolider", model.id_notificacao));

                    if (model.UsuarioOperador.rl_usuario == 0)
                        command.Parameters.Add(new SqlParameter("@cd_rl_operador", DBNull.Value));
                    else
                        command.Parameters.Add(new SqlParameter("@cd_rl_operador", model.UsuarioOperador.rl_usuario));

                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                TB_NOTIFICACAOLIDER tbNotifica = new TB_NOTIFICACAOLIDER();
                                tbNotifica.id_notificacao = Convert.ToInt32(result["id_notificacao"].ToString());
                                tbNotifica.UsuarioOperador.rl_usuario = string.IsNullOrEmpty(result["id_usuario_operador"].ToString()) ? 0 : Convert.ToInt32(result["id_usuario_operador"].ToString());
                                tbNotifica.UsuarioOperador.nm_usuario = result["nm_usuario"].ToString();
                                tbNotifica.ds_operador_notificacao = result["ds_operador_notificacao"].ToString();

                                tbNotifica.dt_lider_leitura = result["dt_lider_leitura"].ToString();
                                tbNotifica.dt_operador_envio = result["dt_operador_envio"].ToString();
                                tbNotifica.ds_lider_notificacao = result["ds_lider_notificacao"].ToString();
                                tbNotifica.dt_lider_gravacao = result["dt_lider_gravacao"].ToString();
                                
                                tbNotifica.UsuarioLiderLeitura.rl_usuario = string.IsNullOrEmpty(result["id_usuario_lider_leitura"].ToString()) ? 0 : Convert.ToInt32(result["id_usuario_lider_leitura"].ToString());
                                tbNotifica.UsuarioLiderLeitura.nm_usuario = result["nm_lider_leitura"].ToString();

                                tbNotifica.UsuarioLiderNotificacao.rl_usuario = string.IsNullOrEmpty(result["id_usuario_lider_notificacao"].ToString()) ? 0 : Convert.ToInt32(result["id_usuario_lider_notificacao"].ToString());
                                tbNotifica.UsuarioLiderNotificacao.nm_usuario = result["nm_lider_notificacao"].ToString();

                              //  tbNotifica.Formulario.id_formulario = Convert.ToInt32(result["id_formulario"].ToString());
                                //tbNotifica.Formulario.ds_nome = result["ds_nome"].ToString();

                              //  tbNotifica.Formulario.Maquina.nm_maquina = result["nm_maquina"].ToString();
                                //tbNotifica.Formulario.Maquina.departamento.depto = result["ds_departamento"].ToString();
                                //tbNotifica.Formulario.Maquina.departamento.codigo_departamento = string.IsNullOrEmpty(result["codigo_departamento"].ToString()) ? 0 : Convert.ToInt32(result["codigo_departamento"].ToString());
                             //  tbNotifica.Formulario.MaquinaParte.ds_maquina_parte = result["ds_maquina_parte"].ToString();

                                lModelos.Add(tbNotifica);
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

        public List<TB_USUARIO> ConsultarListaUsuarios(string pFiltro, int? id_departamento)
        {
            try
            {
                List<TB_USUARIO> lista = new List<TB_USUARIO>();

                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_lista_usuariooperador";
                    command.CommandType = CommandType.StoredProcedure;

                    if (pFiltro.Length == 0)
                        command.Parameters.Add(new SqlParameter("@ds_permissao", DBNull.Value));
                    else
                        command.Parameters.Add(new SqlParameter("@ds_permissao", pFiltro));

                    if (id_departamento == 0)
                        command.Parameters.Add(new SqlParameter("@id_departamento", DBNull.Value));
                    else
                        command.Parameters.Add(new SqlParameter("@id_departamento", id_departamento));


                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                TB_USUARIO obj = new TB_USUARIO();
                                obj.rl_usuario = Convert.ToInt32(result["cd_rl"].ToString());
                                obj.nm_usuario = result["nm_usuario"].ToString();

                                lista.Add(obj);
                            }
                        }
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GravarNotificacaoLider(TB_NOTIFICACAOLIDER dado)
        {
            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_update_notificacaolider";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@id_notificacao", dado.id_notificacao));
                    command.Parameters.Add(new SqlParameter("@ds_lider_notificacao", dado.ds_lider_notificacao));
                    command.Parameters.Add(new SqlParameter("@id_usuario_lider_notificacao", dado.UsuarioLiderNotificacao.rl_usuario));

                    Context.Database.OpenConnection();
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AtualizaDataLeituraLider(TB_NOTIFICACAOLIDER modelo)
        {
            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_update_dataleituraLider";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@id_usuario_lider_leitura", modelo.UsuarioLiderLeitura.rl_usuario));
                    command.Parameters.Add(new SqlParameter("@id_notificacao", modelo.id_notificacao));
                    //command.Parameters.Add(new SqlParameter("@id_usuario_lider_leitura", formularioModel.id_status));    // DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");

                    Context.Database.OpenConnection();
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
