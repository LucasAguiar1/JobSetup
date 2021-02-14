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
    public class Formulario_OrdemRepository : SpecRepository<TB_FORMULARIO>
    {
        public Formulario_OrdemRepository(ApplicationDbSpecContext context) : base(context)
        {
        }

        public TB_ORDEM_FORMULARIO Cadastrar(TB_ORDEM_FORMULARIO ordemFormulario)
        {
            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_insert_Formulario_Ordem";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@id_formulario", ordemFormulario.id_Formulario));
                    command.Parameters.Add(new SqlParameter("@id_formulario_Filho", ordemFormulario.id_formulario_Filho));
                    command.Parameters.Add(new SqlParameter("@idUsuario", ordemFormulario.idUsuario));
                    command.Parameters.Add(new SqlParameter("@tipo", ordemFormulario.tipo));
                    command.Parameters.Add(new SqlParameter("@id_departamento", ordemFormulario.id_departamento));
                    command.Parameters.Add(new SqlParameter("@ordem", ordemFormulario.orderm_Formulario));


                    command.Parameters.Add(new SqlParameter("@idRetorno", ordemFormulario.idRetorno) { Size = 200, Direction = ParameterDirection.Output });

                    Context.Database.OpenConnection();
                    command.ExecuteScalar();

                    if (Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value) != 0)
                    {
                        ordemFormulario.id = Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value);

                        if (ordemFormulario.tipo.Equals("C"))
                        {
                            ordemFormulario.msn = "Cadastro efetuado com sucesso.";
                        }

                    }
                    else
                    {
                        ordemFormulario.msn = "Por favor, entre em contato com o Administrador.";
                    }
                }

                return ordemFormulario;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public TB_ORDEM_FORMULARIO Excluir(TB_ORDEM_FORMULARIO ordemFormulario)
        {
            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_Delete_Formulario_Ordem";
                    command.CommandType = CommandType.StoredProcedure;

                    //command.Parameters.Add(new SqlParameter("@id", ordemFormulario.id));
                    command.Parameters.Add(new SqlParameter("@id_formulario", ordemFormulario.id_Formulario));
                    command.Parameters.Add(new SqlParameter("@id_formulario_Filho", ordemFormulario.id_formulario_Filho));
                    command.Parameters.Add(new SqlParameter("@id_departamento", ordemFormulario.id_departamento));
                    
                    Context.Database.OpenConnection();
                    command.ExecuteScalar();


                    ordemFormulario.msn = "Atualização efetuada com sucesso.";

                }

                return ordemFormulario;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public TB_ORDEM_FORMULARIO Alterar(TB_ORDEM_FORMULARIO ordemFormulario)
        {
            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_update_Formulario_Ordem";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@id_formulario", ordemFormulario.id_Formulario));
                    command.Parameters.Add(new SqlParameter("@id", ordemFormulario.id));
                    command.Parameters.Add(new SqlParameter("@id_formulario_Filho", ordemFormulario.id_formulario_Filho));
                    command.Parameters.Add(new SqlParameter("@idusuarioAlt", ordemFormulario.idUsuarioAlt));
                    command.Parameters.Add(new SqlParameter("@tipo", ordemFormulario.tipo));
                    command.Parameters.Add(new SqlParameter("@id_departamento", ordemFormulario.id_departamento));
                    command.Parameters.Add(new SqlParameter("@ordem", ordemFormulario.orderm_Formulario));

                    Context.Database.OpenConnection();
                    command.ExecuteScalar();

                    ordemFormulario.msn = "Atualização efetuada com sucesso.";
                }

                return ordemFormulario;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public List<TB_ORDEM_FORMULARIO> Consultar(TB_ORDEM_FORMULARIO ordemFormulario)
        {
            try
            {
                List<TB_ORDEM_FORMULARIO> listFormulario = new List<TB_ORDEM_FORMULARIO>();

                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {

                    command.CommandText = "sp_consulta_OrdemFormularioformulario";

                    command.Parameters.Add(new SqlParameter("@id_Formulario", ordemFormulario.id_Formulario));

                    command.CommandType = CommandType.StoredProcedure;

                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                TB_ORDEM_FORMULARIO formulario = new TB_ORDEM_FORMULARIO();
                                formulario.id = Convert.ToInt32(result["id"].ToString());
                                formulario.id_Formulario = Convert.ToInt32(result["id_formulario"].ToString());
                                formulario.id_formulario_Filho = Convert.ToInt32(result["id_formulario_filho"].ToString());
                                formulario.idUsuarioAlt = result["idUsuarioAlt"].ToString();
                                formulario.idUsuario = result["idUsuario"].ToString();
                                formulario.tipo = result["tipo"].ToString();
                                formulario.id_departamento = Convert.ToInt32(result["id_departamento"].ToString());
                                formulario.orderm_Formulario = Convert.ToInt32(result["ordem"].ToString());

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
    }
}
