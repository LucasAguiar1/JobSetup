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
    public class PerguntaRepository : SpecRepository<TB_PERGUNTA>
    {
        public PerguntaRepository(ApplicationDbSpecContext context) : base(context)
        {
        }

        public List<TB_PERGUNTA> Consultar(TB_PERGUNTA pergunta)
        {

            List<TB_PERGUNTA> lPergunta = new List<TB_PERGUNTA>();

            try
            {

                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_pergunta";
                    command.CommandType = CommandType.StoredProcedure;

                    if (pergunta.id == 0)
                    {
                        command.Parameters.Add(new SqlParameter("@id", DBNull.Value));
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("@id", pergunta.id));
                    }

                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                TB_PERGUNTA tbPergunta = new TB_PERGUNTA();
                                tbPergunta.id = Convert.ToInt32(result["id"].ToString());
                                tbPergunta.idUsuario = result["idUsuario"].ToString();
                                tbPergunta.id_formulario = Convert.ToInt32(result["id_formulario"].ToString());
                                tbPergunta.id_obrigatorio = Convert.ToInt32(result["id_obrigatorio"].ToString());
                                tbPergunta.descObrigatorio = tbPergunta.id_obrigatorio == 1 ? "Sim" : "Não";
                                tbPergunta.id_tess = Convert.ToInt32(result["id_tess"].ToString());
                                tbPergunta.descTess = tbPergunta.id_tess == 1 ? "Sim" : "Não";
                                tbPergunta.id_tipoResposta = Convert.ToInt32(result["id_tipoResposta"].ToString());
                                tbPergunta.nome = result["nome"].ToString();
                                tbPergunta.ordemApresentacao = result["ordemApresentacao"].ToString();
                                tbPergunta.status = Convert.ToInt32(result["status"].ToString());
                                tbPergunta.tipo = result["tipo"].ToString();
                                tbPergunta.dataRegistro = result["dataRegistro"].ToString();
                                tbPergunta.formulario = result["formulario"].ToString();
                                tbPergunta.resposta = result["Resposta"].ToString();
                                tbPergunta.id_departamento = Convert.ToInt32(result["id_departamento"].ToString());
                                tbPergunta.id_maquina = Convert.ToInt32(result["id_maquina"].ToString());
                                tbPergunta.id_parteMaquina = Convert.ToInt32(result["id_parteMaquina"].ToString());
                                tbPergunta.maquina = result["maquina"].ToString();
                                tbPergunta.maquinaParte = result["maquinaParte"].ToString();
                                tbPergunta.departamento = result["departamento"].ToString();
                                tbPergunta.idPai = result["idPai"].ToString();
                                tbPergunta.idsAlternativa = result["idsAlternativa"].ToString();

                                lPergunta.Add(tbPergunta);
                            }
                        }
                    }

                    return lPergunta;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public List<TB_PERGUNTA> Consulta_perguntaSemPai(TB_PERGUNTA pergunta)
        {

            List<TB_PERGUNTA> lPergunta = new List<TB_PERGUNTA>();

            try
            {

                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_perguntaSemPai";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@idFormulario", pergunta.id_formulario));

                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                TB_PERGUNTA tbPergunta = new TB_PERGUNTA();
                                tbPergunta.id = Convert.ToInt32(result["id"].ToString());
                                tbPergunta.id_formulario = Convert.ToInt32(result["id_formulario"].ToString());
                                tbPergunta.idUsuario = result["idUsuario"].ToString();
                                tbPergunta.status = Convert.ToInt32(result["status"].ToString());
                                tbPergunta.nome = result["nome"].ToString();
                                tbPergunta.id_tipoResposta = Convert.ToInt32(result["id_tipoResposta"].ToString());
                                tbPergunta.id_obrigatorio = Convert.ToInt32(result["id_obrigatorio"].ToString());
                                tbPergunta.descObrigatorio = tbPergunta.id_obrigatorio == 1 ? "Sim" : "Não";
                                tbPergunta.id_tess = Convert.ToInt32(result["id_tess"].ToString());
                                tbPergunta.descTess = tbPergunta.id_tess == 1 ? "Sim" : "Não";
                                tbPergunta.ordemApresentacao = result["ordemApresentacao"].ToString();
                                tbPergunta.tipo = result["tipo"].ToString();
                                tbPergunta.dataRegistro = result["dataRegistro"].ToString();
                                tbPergunta.idsAlternativa = result["idsAlternativa"].ToString();

                                lPergunta.Add(tbPergunta);
                            }
                        }
                    }

                    return lPergunta;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public List<SelectListItem> Combo(List<TB_PERGUNTA> lPergunta, string opcaoInicial)
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            if (!string.IsNullOrEmpty(opcaoInicial))
            {
                lista.Add(new SelectListItem //adiciona uma opção que convida a escolher uma das possíveis opções
                {
                    Text = opcaoInicial,
                    Value = "0"
                });
            }

            foreach (var Linha in lPergunta)
            {
                lista.Add(new SelectListItem()
                {
                    Value = Linha.id.ToString(),
                    Text = Linha.nome
                });
            }

            return lista;
        }

        public TB_PERGUNTA AtualizarAlternativa(TB_PERGUNTA pergunta)
        {
            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_update_perguntaAlternativa";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@idUsuario", pergunta.idUsuario));
                    command.Parameters.Add(new SqlParameter("@id", pergunta.id));
                    command.Parameters.Add(new SqlParameter("@idsAlternativa", pergunta.idsAlternativa));
                    Context.Database.OpenConnection();
                    command.ExecuteScalar();

                    pergunta.msn = "Alternativa excluída com sucesso da Pergunta.";

                }

                return pergunta;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public TB_PERGUNTA Alterar(TB_PERGUNTA pergunta)
        {
            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_update_perguntaPai";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@id", pergunta.id));
                    command.Parameters.Add(new SqlParameter("@id_formulario", pergunta.id_formulario));
                    command.Parameters.Add(new SqlParameter("@status", pergunta.status));
                    command.Parameters.Add(new SqlParameter("@nome", pergunta.nome));
                    command.Parameters.Add(new SqlParameter("@id_tipoResposta", pergunta.id_tipoResposta));
                    command.Parameters.Add(new SqlParameter("@id_obrigatorio", pergunta.id_obrigatorio));
                    command.Parameters.Add(new SqlParameter("@id_tess", pergunta.id_tess));
                    command.Parameters.Add(new SqlParameter("@ordemApresentacao", pergunta.ordemApresentacao));
                    command.Parameters.Add(new SqlParameter("@idUsuarioAlt", pergunta.idUsuario));
                    command.Parameters.Add(new SqlParameter("@tipo", pergunta.tipo));
                    command.Parameters.Add(new SqlParameter("@idsAlternativa", pergunta.idsAlternativa == null ? string.Empty : pergunta.idsAlternativa));


                    Context.Database.OpenConnection();
                    command.ExecuteScalar();

                    pergunta.msn = "Atualização efetuada com sucesso.";

                }

                return pergunta;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public TB_PERGUNTA Cadastrar(TB_PERGUNTA pergunta)
        {
            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_insert_pergunta";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@idUsuario", pergunta.idUsuario));
                    command.Parameters.Add(new SqlParameter("@id_formulario", pergunta.id_formulario));
                    command.Parameters.Add(new SqlParameter("@id_obrigatorio", pergunta.id_obrigatorio));
                    command.Parameters.Add(new SqlParameter("@id_tess", pergunta.id_tess));
                    command.Parameters.Add(new SqlParameter("@id_tipoResposta", pergunta.id_tipoResposta));
                    command.Parameters.Add(new SqlParameter("@nome", pergunta.nome));
                    command.Parameters.Add(new SqlParameter("@ordemApresentacao", pergunta.ordemApresentacao));
                    command.Parameters.Add(new SqlParameter("@status", pergunta.status));
                    command.Parameters.Add(new SqlParameter("@tipo", pergunta.tipo));
                    command.Parameters.Add(new SqlParameter("@idsAlternativa", pergunta.idsAlternativa));

                    command.Parameters.Add(new SqlParameter("@idRetorno", pergunta.id) { Size = 200, Direction = ParameterDirection.Output });

                    Context.Database.OpenConnection();
                    command.ExecuteScalar();

                    if (Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value) != 0)
                    {
                        pergunta.id = Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value);

                        if (pergunta.tipo.Equals("C"))
                        {
                            pergunta.msn = "Cadastro efetuado com sucesso.";
                        }
                        else
                        {
                            pergunta.msn = "Atualização efetuada com sucesso.";
                        }
                    }
                    else
                    {
                        pergunta.msn = "Por favor, entre em contato com o Administrador.";
                    }
                }

                return pergunta;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
