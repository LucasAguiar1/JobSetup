using BridgestoneLibras.Data;
using BridgestoneLibras.Data.Repository;
using BridgestoneLibras.Models;
using BridgestoneLibras.ModelsEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LHH.Data.Repository
{
    public class NotificacaoRepository : SpecRepository<TB_NOTIFICACAO>
    {
        public NotificacaoRepository(ApplicationDbSpecContext context) : base(context)
        {

        }

        public List<TB_NOTIFICACAO> Consultar(TB_NOTIFICACAO notificacao)
        {
            try
            {
                List<TB_NOTIFICACAO> lnotificacao = new List<TB_NOTIFICACAO>();
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_notificacaolider";
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.Add(new SqlParameter("@id_formulario", notificacao.id_formulario));
                    command.Parameters.Add(new SqlParameter("@respondidas", notificacao.respondidas));
                    command.Parameters.Add(new SqlParameter("@idDepartamento", notificacao.id_departamento));
                    command.Parameters.Add(new SqlParameter("@id_lider", notificacao.id_lider == null ? "" : notificacao.id_lider));



                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                TB_NOTIFICACAO tbNotifica = new TB_NOTIFICACAO();
                                tbNotifica.id_nomeOperador = result["id_nomeOperador"].ToString();
                                tbNotifica.dataNotificacao = result["dataNotificacao"].ToString() == null ? string.Empty : result["dataNotificacao"].ToString();
                                tbNotifica.dataLeitura = result["dataLeitura"].ToString() == null ? string.Empty : result["dataLeitura"].ToString();
                                tbNotifica.dataObsLider = result["dataObsLider"].ToString() == null ? string.Empty : result["dataObsLider"].ToString();

                                tbNotifica.notificacao = result["notificacao"].ToString();
                                tbNotifica.observacaoLider = result["observacaoLider"].ToString() == null ? string.Empty : result["observacaoLider"].ToString();

                                tbNotifica.maquinaParte = result["maquinaParte"].ToString();
                                tbNotifica.maquina = result["maquina"].ToString();
                                tbNotifica.maquinaParte = result["MaquinaParte"].ToString();
                                tbNotifica.formulario = result["Formulario"].ToString();
                                tbNotifica.id_lider = result["id_lider"].ToString();
                                tbNotifica.id = Convert.ToInt32(result["id"].ToString());
                                tbNotifica.nomeLider = result["nomeLider"].ToString();
                                tbNotifica.Departamento = result["Departamento"].ToString();

                                lnotificacao.Add(tbNotifica);
                            }
                        }
                    }
                }

                return lnotificacao;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<TB_USUARIO> ConsultarListaUsuarios(string codigo)
        {
            try
            {
                List<TB_USUARIO> lista = new List<TB_USUARIO>();

                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_carrega_lider";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@departamento", codigo));

                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                TB_USUARIO obj = new TB_USUARIO();
                                
                                obj.nm_usuario = result["chrfirstname"].ToString();
                                obj.id_departamento = Convert.ToInt32(result["departamento"].ToString());
                                obj.funcao = result["funcao"].ToString();
                                obj.ds_login = result["login"].ToString(); 

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

        public List<SelectListItem> Combo(List<TB_USUARIO> lDepartamento, string opcaoInicial)
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

            foreach (var Linha in lDepartamento)
            {
                lista.Add(new SelectListItem()
                {
                    Value = Linha.ds_login.ToString(),
                    Text = Linha.id_departamento + "-" + Linha.nm_usuario 
                });
            }

            return lista;
        }

        public TB_NOTIFICACAO Cadastrar(TB_NOTIFICACAO notificacao)
        {
            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_insert_notificacaolider";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@notificacao", notificacao.notificacao));
                    command.Parameters.Add(new SqlParameter("@id_formulario", notificacao.id_formulario));
                    command.Parameters.Add(new SqlParameter("@id_usuario", notificacao.id_usuario));
                    command.Parameters.Add(new SqlParameter("@id_lider", notificacao.id_lider == "" ? "0" : notificacao.id_lider));
                    command.Parameters.Add(new SqlParameter("@id_nomeOperador", notificacao.id_nomeOperador));
                    command.Parameters.Add(new SqlParameter("@idRetorno", notificacao.id) { Size = 200, Direction = ParameterDirection.Output });

                    Context.Database.OpenConnection();
                    command.ExecuteNonQuery();


                    if (Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value) != 0)
                    {
                        notificacao.id = Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value);
                        {
                            notificacao.msn = "Notificação efetuada com sucesso.";
                        }
                    }
                    else
                    {
                        notificacao.msn = "Por favor, entre em contato com o Administrador.";
                    }
                }
                return notificacao;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public TB_NOTIFICACAO Atualizar(TB_NOTIFICACAO notificacao)
        {


            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_update_ObsLider";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@id_liderObs", notificacao.id_liderObs));
                    command.Parameters.Add(new SqlParameter("@id", notificacao.id));
                    command.Parameters.Add(new SqlParameter("@nomeLider", notificacao.nomeLider));
                    command.Parameters.Add(new SqlParameter("@observacaoLider", notificacao.observacaoLider));

                    command.Parameters.Add(new SqlParameter("@result", notificacao.id));

                    Context.Database.OpenConnection();
                    command.ExecuteNonQuery();

                    if (Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value) != 0)
                    {
                        notificacao.result = Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value);

                        if (notificacao.result == 0)
                        {
                            notificacao.msn = "Por favor, entre em contato com o Administrador.";
                        }
                        else
                        {
                            notificacao.msn = "Notificação Atualizada com sucesso";
                        }
                    }
                    else
                    {
                        notificacao.msn = "Por favor, entre em contato com o Administrador.";
                    }

                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return notificacao;
        }

        public TB_NOTIFICACAO AtualizarLeitura(TB_NOTIFICACAO notificacao)
        {


            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_update_dataleituraLider";
                    command.CommandType = CommandType.StoredProcedure;

                    //command.Parameters.Add(new SqlParameter("@id_lider", notificacao.id_lider));
                    command.Parameters.Add(new SqlParameter("@id", notificacao.id));
                    command.Parameters.Add(new SqlParameter("@nomeLider", notificacao.nomeLider));

                    command.Parameters.Add(new SqlParameter("@result", notificacao.id));


                    Context.Database.OpenConnection();
                    command.ExecuteNonQuery();

                    if (Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value) != 0)
                    {
                        notificacao.result = Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value);

                        if (notificacao.result == 0)
                        {
                            notificacao.msn = "Por favor, entre em contato com o Administrador.";
                        }
                    }
                    else
                    {
                        notificacao.msn = "Por favor, entre em contato com o Administrador.";
                    }

                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return notificacao;
        }
    }
}
