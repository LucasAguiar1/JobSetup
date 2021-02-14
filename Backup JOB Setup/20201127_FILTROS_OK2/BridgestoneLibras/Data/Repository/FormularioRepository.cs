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
using System.Linq;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace LHH.Data.Repository
{
    public class FormularioRepository : SpecRepository<TB_FORMULARIO>
    {
        public FormularioRepository(ApplicationDbSpecContext context) : base(context)
        {
        }

        public TB_FORMULARIO Cadastrar(TB_FORMULARIO formulario)
        {
            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_insert_formulario";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@idUsuario", formulario.idUsuario));
                    command.Parameters.Add(new SqlParameter("@id_maquina", formulario.id_maquina));
                    command.Parameters.Add(new SqlParameter("@id_parteMaquina", formulario.id_parteMaquina));
                    command.Parameters.Add(new SqlParameter("@nome", formulario.nome));
                    command.Parameters.Add(new SqlParameter("@status", formulario.status));
                    command.Parameters.Add(new SqlParameter("@tipo", formulario.tipo));

                    command.Parameters.Add(new SqlParameter("@idRetorno", formulario.id) { Size = 200, Direction = ParameterDirection.Output });

                    Context.Database.OpenConnection();
                    command.ExecuteScalar();

                    if (Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value) != 0)
                    {
                        formulario.id = Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value);

                        if (formulario.tipo.Equals("C"))
                        {
                            formulario.msn = "Cadastro efetuado com sucesso.";
                        }
                        else
                        {
                            formulario.msn = "Atualização efetuada com sucesso.";
                        }
                    }
                    else
                    {
                        formulario.msn = "Por favor, entre em contato com o Administrador.";
                    }
                }

                return formulario;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public TB_FORMULARIO Alterar(TB_FORMULARIO formulario)
        {
            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_update_formulario";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@idUsuarioAlt", formulario.idUsuario));
                    command.Parameters.Add(new SqlParameter("@id_maquina", formulario.id_maquina));
                    command.Parameters.Add(new SqlParameter("@id_parteMaquina", formulario.id_parteMaquina));
                    command.Parameters.Add(new SqlParameter("@nome", formulario.nome));
                    command.Parameters.Add(new SqlParameter("@status", formulario.status));
                    command.Parameters.Add(new SqlParameter("@tipo", formulario.tipo));
                    command.Parameters.Add(new SqlParameter("@id", formulario.id));

                    Context.Database.OpenConnection();
                    command.ExecuteScalar();

                    formulario.msn = "Atualização efetuada com sucesso.";
                }

                return formulario;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<TB_FORMULARIO> Consultar()
        {
            try
            {
                List<TB_FORMULARIO> listFormulario = new List<TB_FORMULARIO>();

                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_formulario";
                    command.CommandType = CommandType.StoredProcedure;

                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                TB_FORMULARIO formulario = new TB_FORMULARIO();
                                formulario.id = Convert.ToInt32(result["id"].ToString());
                                formulario.id_departamento = Convert.ToInt32(result["id_departamento"].ToString());
                                formulario.dataRegistro = result["dataRegistro"].ToString();
                                formulario.idUsuario = result["idUsuario"].ToString();
                                formulario.id_maquina = Convert.ToInt32(result["id_maquina"].ToString());
                                formulario.id_parteMaquina = Convert.ToInt32(result["id_parteMaquina"].ToString());
                                formulario.nome = result["nome"].ToString();
                                formulario.status = Convert.ToInt32(result["status"].ToString());
                                formulario.tipo = result["tipo"].ToString();
                                formulario.maquina = result["maquina"].ToString();
                                formulario.parteMaquina = result["PARTEMAQUINA"].ToString();
                                formulario.departamento = result["DEPARTAMENTO"].ToString();

                                listFormulario.Add(formulario);
                            }
                        }
                    }
                }

                return listFormulario;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<TB_FORMULARIO> Consultar(TB_FORMULARIO form)
        {
            try
            {
                List<TB_FORMULARIO> listFormulario = new List<TB_FORMULARIO>();

                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_formulario";
                    command.CommandType = CommandType.StoredProcedure;

                    if (form.id == 0)
                    {
                        command.Parameters.Add(new SqlParameter("@id_parteMaquina", null));
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("@id_parteMaquina", form.id));
                    }

                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                TB_FORMULARIO formulario = new TB_FORMULARIO();
                                formulario.id = Convert.ToInt32(result["id"].ToString());
                                formulario.id_departamento = Convert.ToInt32(result["id_departamento"].ToString());
                                formulario.dataRegistro = result["dataRegistro"].ToString();
                                formulario.idUsuario = result["idUsuario"].ToString();
                                formulario.id_maquina = Convert.ToInt32(result["id_maquina"].ToString());
                                formulario.id_parteMaquina = Convert.ToInt32(result["id_parteMaquina"].ToString());
                                formulario.nome = result["nome"].ToString();
                                formulario.status = Convert.ToInt32(result["status"].ToString());
                                formulario.tipo = result["tipo"].ToString();
                                formulario.maquina = result["maquina"].ToString();
                                formulario.parteMaquina = result["PARTEMAQUINA"].ToString();
                                formulario.departamento = result["DEPARTAMENTO"].ToString();

                                listFormulario.Add(formulario);
                            }
                        }
                    }
                }

                return listFormulario;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<TB_PERGUNTA> ConsultaPerguntasPorFormulario(TB_PERGUNTA pergunta)
        {
            try
            {
                List<TB_PERGUNTA> lPerguntas = new List<TB_PERGUNTA>();

                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_perguntaFormulario";
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.Add(new SqlParameter("@id_Formulario", pergunta.id_formulario));

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

                                tbPergunta.nomeFormulario = result["nomeFormulario"].ToString();

                                lPerguntas.Add(tbPergunta);

                            }
                        }
                    }
                }

                return lPerguntas;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        
        public List<SelectListItem> Combo(List<TB_FORMULARIO> lFormulario, string opcaoInicial)
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

            foreach (var Linha in lFormulario)
            {
                lista.Add(new SelectListItem()
                {
                    Value = Linha.id.ToString(),
                    Text = Linha.nome
                });
            }

            return lista;
        }
    }
}
