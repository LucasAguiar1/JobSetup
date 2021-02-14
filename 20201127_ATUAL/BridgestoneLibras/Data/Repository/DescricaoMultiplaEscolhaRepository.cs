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
    public class DescricaoMultiplaEscolhaRepository : SpecRepository<TB_DescricaoMultiplaEscolha>
    {
        public DescricaoMultiplaEscolhaRepository(ApplicationDbSpecContext context) : base(context)
        {
        }

        public List<TB_DescricaoMultiplaEscolha> Consultar(TB_DescricaoMultiplaEscolha descricao)
        {
            try
            {
                List<TB_DescricaoMultiplaEscolha> lDescricao = new List<TB_DescricaoMultiplaEscolha>();
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_DescricaoMultiplaEscolha";
                    command.CommandType = CommandType.StoredProcedure;
                    if (descricao.id != 0)
                    {
                        command.Parameters.Add(new SqlParameter("@id", descricao.id));
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
                                TB_DescricaoMultiplaEscolha tDescricao = new TB_DescricaoMultiplaEscolha();
                                tDescricao.id = Convert.ToInt32(result["id"].ToString());
                                tDescricao.nome = result["nome"].ToString();
                                tDescricao.status = Convert.ToInt32(result["status"].ToString());
                                tDescricao.id_TipoResposta = Convert.ToInt32(result["id_TipoResposta"].ToString());


                                lDescricao.Add(tDescricao);
                            }
                        }
                    }
                }
                return lDescricao;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }



        public List<TB_DescricaoMultiplaEscolha> ConsultarPorPergunta(TB_DescricaoMultiplaEscolha descricao)
        {
            try
            {
                List<TB_DescricaoMultiplaEscolha> lDescricao = new List<TB_DescricaoMultiplaEscolha>();
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_DescricaoMultiplaEscolhaPorPergunta";
                    command.CommandType = CommandType.StoredProcedure;
                    if (descricao.id != 0)
                    {
                        command.Parameters.Add(new SqlParameter("@id", descricao.id));
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
                                TB_DescricaoMultiplaEscolha tDescricao = new TB_DescricaoMultiplaEscolha();
                                tDescricao.id = Convert.ToInt32(result["id"].ToString());
                                tDescricao.nome = result["nome"].ToString();
                                tDescricao.status = Convert.ToInt32(result["status"].ToString());
                                tDescricao.id_TipoResposta = Convert.ToInt32(result["id_TipoResposta"].ToString());


                                lDescricao.Add(tDescricao);
                            }
                        }
                    }
                }
                return lDescricao;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<SelectListItem> Combo(List<TB_DescricaoMultiplaEscolha> lparte, string opcaoInicial)
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

            foreach (var Linha in lparte)
            {
                lista.Add(new SelectListItem()
                {
                    Value = Linha.id.ToString(),
                    Text = Linha.nome
                });
            }

            return lista;
        }

        public TB_DescricaoMultiplaEscolha Alterar(TB_DescricaoMultiplaEscolha descricao)
        {

            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {

                    command.CommandText = "sp_update_DescricaoMultiplaEscolha";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@nome", descricao.nome));
                    command.Parameters.Add(new SqlParameter("@status", descricao.status));
                    command.Parameters.Add(new SqlParameter("@id_TipoResposta", descricao.id_TipoResposta));
                    command.Parameters.Add(new SqlParameter("@idUsuarioAlt", descricao.idUsuario));
                    command.Parameters.Add(new SqlParameter("@tipo", descricao.tipo));
                    command.Parameters.Add(new SqlParameter("@id", descricao.id));

                    Context.Database.OpenConnection();
                    command.ExecuteScalar();


                    descricao.msn = "Atualização efetuada com sucesso.";

                }

                return descricao;
            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }
        public TB_DescricaoMultiplaEscolha Cadastrar(TB_DescricaoMultiplaEscolha descricao)
        {

            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {

                    command.CommandText = "sp_insert_DescricaoMultiplaEscolha";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@nome", descricao.nome));
                    command.Parameters.Add(new SqlParameter("@status", descricao.status));
                    command.Parameters.Add(new SqlParameter("@id_TipoResposta", descricao.id_TipoResposta));
                    command.Parameters.Add(new SqlParameter("@idUsuario", descricao.idUsuario));
                    command.Parameters.Add(new SqlParameter("@tipo", descricao.tipo));
                    command.Parameters.Add(new SqlParameter("@idRetorno", descricao.id) { Size = 200, Direction = ParameterDirection.Output });

                    Context.Database.OpenConnection();
                    command.ExecuteScalar();

                    if (Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value) != 0)
                    {
                        descricao.id = Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value);

                        if (descricao.tipo.Equals("C"))
                        {
                            descricao.msn = "Cadastro efetuado com sucesso.";
                        }
                        else
                        {
                            descricao.msn = "Atualização efetuada com sucesso.";
                        }
                    }
                    else
                    {
                        descricao.msn = "Por favor, entre em contato com o Administrador.";
                    }
                }

                return descricao;
            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }
    }
}

