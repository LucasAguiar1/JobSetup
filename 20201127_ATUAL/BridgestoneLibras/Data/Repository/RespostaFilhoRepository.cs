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
    public class RespostaFilhoRepository : SpecRepository<TB_PERGUNTA>
    {
        public RespostaFilhoRepository(ApplicationDbSpecContext context) : base(context)
        {
        }


        public bool Alterar(List<TB_RespFilho> respFilho, TB_RespPai itemPai)
        {
            try
            {
                foreach (var filho in respFilho)
                {
                    using (var command = Context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "sp_update_respostaFilho";
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@id", filho.chave));
                        command.Parameters.Add(new SqlParameter("@idPai", filho.idPai));
                        command.Parameters.Add(new SqlParameter("@idFilho", filho.id));
                        command.Parameters.Add(new SqlParameter("@id_tipoResposta", filho.id_tipoResposta));
                        command.Parameters.Add(new SqlParameter("@valor", filho.valor));
                        command.Parameters.Add(new SqlParameter("@idUsuario", itemPai.idUsuario));
                        command.Parameters.Add(new SqlParameter("@nomeUsuario", itemPai.nomeUsuario));
                        command.Parameters.Add(new SqlParameter("@idRetorno", filho.idRetorno));

                        Context.Database.OpenConnection();
                        command.ExecuteScalar();

                    }
                }


                if (itemPai.status != "F")
                {
                    itemPai.msn = "Formulário respondido com sucesso.";
                }
                else
                {
                    itemPai.msn = "Formulário finalizado com sucesso.";
                }

                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<TB_RespFilho> Consultar(TB_PERGUNTA tbPai)
        {

            List<TB_RespFilho> lRespFilho = new List<TB_RespFilho>();
            try
            {

                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_RespostaFilho";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@id_Formulario", tbPai.id_formulario));
                    command.Parameters.Add(new SqlParameter("@id_Pai", tbPai.id));


                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                TB_RespFilho filho = new TB_RespFilho();
                                filho.chave = Convert.ToInt32(result["chave"].ToString());
                                filho.idPai = Convert.ToInt32(result["idPai"].ToString());
                                filho.id = Convert.ToInt32(result["idfilho"].ToString());
                                filho.valor = result["valor"].ToString();
                                filho.id_tipoResposta = Convert.ToInt32(result["id_tipoResposta"].ToString());
                                filho.idPreenchimento = Convert.ToInt32(result["idPreenchimento"].ToString());
                                filho.idsAlternativa = result["idsAlternativa"].ToString();
                                lRespFilho.Add(filho);
                            }
                        }
                    }

                    return lRespFilho;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public bool Cadastrar(List<TB_RespFilho> respFilho, TB_RespPai itemPai)
        {
            try
            {
                foreach (var filho in respFilho)
                {

                    using (var command = Context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "sp_insert_RespostaFilho";
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@idFilho", filho.id));
                        command.Parameters.Add(new SqlParameter("@idPai", filho.idPai));

                        command.Parameters.Add(new SqlParameter("@valor", filho.valor == null ? "" : filho.valor.ToString()));
                        command.Parameters.Add(new SqlParameter("@id_tipoResposta", filho.id_tipoResposta));
                        command.Parameters.Add(new SqlParameter("@idUsuario", itemPai.idUsuario));
                        command.Parameters.Add(new SqlParameter("@nomeUsuario", itemPai.nomeUsuario));
                        command.Parameters.Add(new SqlParameter("@idPreenchimento", itemPai.idPreenchimento));
                        command.Parameters.Add(new SqlParameter("@idsAlternativa", itemPai.idsAlternativas));
                        
                        command.Parameters.Add(new SqlParameter("@idRetorno", filho.idRetorno) { Size = 200, Direction = ParameterDirection.Output });

                        Context.Database.OpenConnection();
                        command.ExecuteScalar();


                    }
                }

                if (itemPai.status != "F")
                {
                    itemPai.msn = "Formulário respondido com sucesso.";
                }
                else
                {
                    itemPai.msn = "Formulário finalizado com sucesso.";
                }



                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
