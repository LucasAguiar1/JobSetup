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
using NPOI.SS.UserModel;

namespace LHH.Data.Repository
{
    public class RespostaRepository : SpecRepository<TB_PERGUNTA>
    {
        public RespostaRepository(ApplicationDbSpecContext context) : base(context)
        {
        }

        public List<TB_RespPai> Consultar(TB_RespPai tbPai)
        {

            List<TB_RespPai> lrespPai = new List<TB_RespPai>();
            try
            {

                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_RespostaPai";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@id_Formulario", tbPai.id_formulario));

                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                TB_RespPai pai = new TB_RespPai();
                                pai.chave = Convert.ToInt32(result["chave"].ToString());
                                pai.id = Convert.ToInt32(result["idPai"].ToString());
                                pai.id_formulario = Convert.ToInt32(result["id_Formulario"].ToString());
                                pai.valor = result["valor"].ToString();
                                pai.status = result["status"].ToString();
                                pai.id_tipoResposta = Convert.ToInt32(result["id_tipoResposta"].ToString());
                                pai.idPreenchimento = Convert.ToInt32(result["idPreenchimento"].ToString());
                                pai.idsAlternativas = result["idsAlternativa"] == null ? string.Empty : result["idsAlternativa"].ToString();
                                
                                lrespPai.Add(pai);
                            }
                        }
                    }

                    return lrespPai;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public bool Alterar(TB_RespPai tbPai)
        {
            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_update_RespostaPai";
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.Add(new SqlParameter("@id_Formulario", tbPai.id_formulario));
                    command.Parameters.Add(new SqlParameter("@id", tbPai.chave));
                    command.Parameters.Add(new SqlParameter("@idPai", tbPai.id));
                    command.Parameters.Add(new SqlParameter("@id_tipoResposta", tbPai.id_tipoResposta));
                    command.Parameters.Add(new SqlParameter("@valor", tbPai.valor));
                    command.Parameters.Add(new SqlParameter("@idUsuario", tbPai.idUsuario));
                    command.Parameters.Add(new SqlParameter("@nomeUsuario", tbPai.nomeUsuario));
                    command.Parameters.Add(new SqlParameter("@status", tbPai.status));
                    command.Parameters.Add(new SqlParameter("@idRetorno", tbPai.idRetorno));

                    Context.Database.OpenConnection();
                    command.ExecuteScalar();

                    if (tbPai.status != "F")
                    {
                        tbPai.msn = "Formulário salvo com sucesso.";
                    }
                    else
                    {
                        tbPai.msn = "Formulário finalizado com sucesso.";
                    }

                    return true;

                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool Cadastrar(TB_RespPai respPai)
        {

            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_insert_RespostaPai";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@idPai", respPai.id));
                    command.Parameters.Add(new SqlParameter("@id_tipoResposta", respPai.id_tipoResposta));
                    command.Parameters.Add(new SqlParameter("@valor", respPai.valor == null ? "" : respPai.valor.ToString()));
                    command.Parameters.Add(new SqlParameter("@status", respPai.status));
                    command.Parameters.Add(new SqlParameter("@idUsuario", respPai.idUsuario));
                    command.Parameters.Add(new SqlParameter("@nomeUsuario", respPai.nomeUsuario));
                    command.Parameters.Add(new SqlParameter("@id_formulario", respPai.id_formulario));
                    command.Parameters.Add(new SqlParameter("@idPreenchimento", respPai.idPreenchimento));
                    command.Parameters.Add(new SqlParameter("@idsAlternativa", respPai.idsAlternativas == null ? "" : respPai.idsAlternativas.ToString()));




                    command.Parameters.Add(new SqlParameter("@idRetorno", respPai.idRetorno) { Size = 200, Direction = ParameterDirection.Output });

                    Context.Database.OpenConnection();
                    command.ExecuteScalar();

                    if (Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value) != 0)
                    {
                        respPai.idRetorno = Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value);

                        if (respPai.status != "F")
                        {
                            respPai.msn = "Formulário salvo com sucesso.";
                        }
                        else
                        {
                            respPai.msn = "Formulário finalizado com sucesso.";
                        }
                        return true;
                    }
                    else
                    {

                        respPai.msn = "Por favor, entre em contato com o Administrador.";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<TB_RESPOSTA> ConsultarRelatorio(TB_RESPOSTA resposta)
        {

            List<TB_RESPOSTA> lRespostas = new List<TB_RESPOSTA>();
            try
            {

                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_RespostasPergunta";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@id_formulario", resposta.id_formulario));

                    if (resposta.dataInicio.ToString() == "01/01/0001 00:00:00")
                    {
                        command.Parameters.Add(new SqlParameter("@dataInicio", DBNull.Value));

                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("@dataInicio", resposta.dataInicio.ToString("yyyy-MM-dd")));
                    }

                    if (resposta.dataInicio.ToString() == "01/01/0001 00:00:00")
                    {
                        command.Parameters.Add(new SqlParameter("@dataFim", DBNull.Value));

                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("@dataFim", resposta.dataFim.ToString("yyyy-MM-dd")));
                    }


                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                TB_RESPOSTA resp = new TB_RESPOSTA();

                                //                                resp.departamento =
                                resp.id_formulario = Convert.ToInt32(result["id_formulario"]);
                                resp.status = Convert.ToInt32(result["status"]);
                                resp.pergunta = result["pergunta"].ToString();
                                resp.id_tipoResposta = Convert.ToInt32(result["id_tipoResposta"]);
                                resp.id_obrigatorio = Convert.ToInt32(result["id_obrigatorio"]);
                                resp.ordemApresentacao = Convert.ToInt32(result["ordemApresentacao"]);
                                resp.formulario = result["formulario"].ToString();
                                //resp.re        = result["Resposta"].ToString() == "" ? string.Empty : result["Resposta"].ToString();
                                resp.id_maquina = Convert.ToInt32(result["id_maquina"]);
                                resp.id_parteMaquina = Convert.ToInt32(result["id_parteMaquina"]);
                                resp.id_departamento = Convert.ToInt32(result["id_departamento"]);
                                //resp.nome             = result["nome"];
                                resp.maquinaParte = result["maquinaParte"].ToString();
                                resp.departamento = result["departamento"].ToString();
                                resp.idsAlternativa = result["idsAlternativa"].ToString();
                                resp.valor = result["valor"].ToString() == null ? "" : result["valor"].ToString();
                                resp.idPai = Convert.ToInt32(result["idPai"]);
                                resp.idPreenchimento = Convert.ToInt32(result["idPreenchimento"]);
                                resp.data =  Convert.ToDateTime(result["DataResposta"].ToString()).ToString("dd/MM/yyyy hh:mm:ss");
                                resp.statusFormulario = result["statusFormulario"].ToString();
                                resp.lotePCS = result["identificadoLote"].ToString();
                                lRespostas.Add(resp);


                            }
                        }
                    }

                    return lRespostas.OrderByDescending(x=> x.data).ToList();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
}
