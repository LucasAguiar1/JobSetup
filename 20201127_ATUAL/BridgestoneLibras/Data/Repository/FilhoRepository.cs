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
    public class FilhoRepository : SpecRepository<TB_FILHO>
    {
        public FilhoRepository(ApplicationDbSpecContext context) : base(context)
        {
        }
        
        public List<TB_FILHO> Consultar(TB_FILHO filho)
        {

            List<TB_FILHO> lFilho = new List<TB_FILHO>();

            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_perguntaFilho";

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id_pergunta_pai", filho.id_perguntaPai));

                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                TB_FILHO tbFilho = new TB_FILHO();

                                tbFilho.id_perguntaPai = Convert.ToInt32(result["id_perguntaPai"].ToString());
                                tbFilho.id_filho = Convert.ToInt32(result["id_filho"].ToString());
                                
                                //tbFilho.id = Convert.ToInt32(result["id"].ToString());

                                tbFilho.nome = result["PerguntaFilho"].ToString();
                                tbFilho.id_tipoResposta = Convert.ToInt32(result["id_tipoResposta"].ToString());
                                
                                tbFilho.resposta = result["Resposta"].ToString();
                                tbFilho.idsAlternativa = result["idsAlternativa"].ToString();
                                tbFilho.id_obrigatorio = Convert.ToInt32(result["id_obrigatorio"].ToString());
                                tbFilho.status = Convert.ToInt32(result["status"].ToString());
                                //tbFilho.id = Convert.ToInt32(result["id"].ToString());
                                //tbFilho.id_perguntaPai = Convert.ToInt32(result["id"].ToString());
                                //tbFilho.idUsuario = result["idUsuario"].ToString();
                                //tbFilho.id_perguntaPai = Convert.ToInt32(result["id_perguntaPai"].ToString());
                                //tbFilho.dataRegistro = result["dataRegistro"].ToString();
                                //tbFilho.tipo = result["tipo"].ToString();
                                //tbFilho.nome = result["PerguntaFilho"].ToString();

                                //tbFilho.descObrigatorio = tbFilho.id_obrigatorio == 1 ? "Sim" : "Não";
                                //tbFilho.id_tess = Convert.ToInt32(result["id_tess"].ToString());
                                //tbFilho.descTess = tbFilho.id_tess == 1 ? "Sim" : "Não";
                                //tbFilho.id_tipoResposta = Convert.ToInt32(result["id_tipoResposta"].ToString());
                                //tbFilho.status = Convert.ToInt32(result["status"].ToString());
                                //tbFilho.resposta = result["Resposta"].ToString();
                                //tbFilho.maquina = result["maquina"].ToString();
                                //tbFilho.maquinaParte = result["maquinaParte"].ToString();
                                //tbFilho.departamento = result["departamento"].ToString();

                                lFilho.Add(tbFilho);
                            }
                        }
                    }

                    return lFilho;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public List<TB_FILHO> Consulta_perguntaFilhoRelatorio(TB_FILHO filho)
        {

            List<TB_FILHO> lFilho = new List<TB_FILHO>();

            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_perguntaFilhoRelatorio";

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@idPreenchimento", filho.idPreenchimento));
                    command.Parameters.Add(new SqlParameter("@idPai", filho.idPai));
                    command.Parameters.Add(new SqlParameter("@id_formulario", filho.id_formulario));
                    
                        

                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                TB_FILHO tbFilho = new TB_FILHO();

                                tbFilho.id_filho = Convert.ToInt32(result["id_filho"].ToString());
                                tbFilho.id_formulario = Convert.ToInt32(result["id_formulario"].ToString());
                                tbFilho.valor = result["valor"].ToString();
                                tbFilho.idsAlternativa = result["idsAlternativa"].ToString();
                                tbFilho.id_tipoResposta = Convert.ToInt32(result["id_tipoResposta"].ToString());
                                tbFilho.nomePergunta = result["nomePergunta"].ToString();



                                lFilho.Add(tbFilho);
                            }
                        }
                    }

                    return lFilho;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public TB_FILHO Excluir(TB_FILHO filho)
        {
            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_delete_perguntaFilho";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@id", filho.id));
                    command.Parameters.Add(new SqlParameter("@idRetorno", filho.id) { Size = 200, Direction = ParameterDirection.Output });

                    Context.Database.OpenConnection();
                    command.ExecuteScalar();

                    filho.msn = "Pergunta Filho Excluido com sucesso.";
                }

                return filho;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public TB_FILHO Cadastrar(TB_FILHO filho)
        {
            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_insert_perguntaFilho";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@idUsuario", filho.idUsuario));
                    command.Parameters.Add(new SqlParameter("@id_perguntaPai", filho.id_perguntaPai));
                    command.Parameters.Add(new SqlParameter("@tipo", filho.tipo));
                    command.Parameters.Add(new SqlParameter("@id_filho", filho.id_filho));
                    command.Parameters.Add(new SqlParameter("@idRetorno", filho.id) { Size = 200, Direction = ParameterDirection.Output });

                    Context.Database.OpenConnection();
                    command.ExecuteScalar();

                    if (Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value) != 0)
                    {
                        filho.id = Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value);

                        if (filho.tipo.Equals("C"))
                        {
                            filho.msn = "Pergunta Filho associada ao Pai com sucesso.";
                        }
                        //else
                        //{
                        //    filho.msn = "Atualização efetuada com sucesso.";
                        //}
                    }
                    else
                    {
                        filho.msn = "Por favor, entre em contato com o Administrador.";
                    }
                }

                return filho;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
