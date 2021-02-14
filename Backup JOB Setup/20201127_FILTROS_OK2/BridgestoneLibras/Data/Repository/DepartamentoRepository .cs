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
    public class DepartamentoRepository : SpecRepository<TB_DEPARTAMENTO>
    {
        public DepartamentoRepository(ApplicationDbSpecContext context) : base(context)
        {
        }

        public List<TB_DEPARTAMENTO> Consultar(TB_DEPARTAMENTO departamento)
        {
            try
            {
                List<TB_DEPARTAMENTO> lDepartamento = new List<TB_DEPARTAMENTO>();
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_departamentos";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@nome", departamento.nome == null ? string.Empty : departamento.nome));
                    if (departamento.id != 0)
                    {
                        command.Parameters.Add(new SqlParameter("@status", departamento.status));
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("@status", 0));
                    }

                    command.Parameters.Add(new SqlParameter("@codigo", departamento.codigo == null ? string.Empty : departamento.codigo));

                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                TB_DEPARTAMENTO tDepartamento = new TB_DEPARTAMENTO();
                                tDepartamento.id = Convert.ToInt32(result["id"].ToString());
                                tDepartamento.nome = result["nome"].ToString();
                                tDepartamento.status = Convert.ToInt32(result["status"].ToString());
                                tDepartamento.codigo = result["codigo"].ToString();


                                lDepartamento.Add(tDepartamento);
                            }
                        }
                    }
                }
                return lDepartamento;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<SelectListItem> Combo(List<TB_DEPARTAMENTO> lDepartamento, string opcaoInicial)
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
                    Value = Linha.id.ToString(),
                    Text =  Linha.codigo + "-" + Linha.nome
                });
            }

            return lista;
        }

        public TB_DEPARTAMENTO Cadatrar(TB_DEPARTAMENTO departamento)
        {

            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {

                    command.CommandText = "sp_insert_departamento";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@nome", departamento.nome));
                    command.Parameters.Add(new SqlParameter("@status", departamento.status));
                    command.Parameters.Add(new SqlParameter("@codigo", departamento.codigo));
                    command.Parameters.Add(new SqlParameter("@idUsuario", departamento.idUsuario));
                    command.Parameters.Add(new SqlParameter("@tipo", departamento.tipo));
                    command.Parameters.Add(new SqlParameter("@idRetorno", departamento.id) { Size = 200, Direction = ParameterDirection.Output });

                    Context.Database.OpenConnection();
                    command.ExecuteScalar();

                    if (Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value) != 0)
                    {
                        departamento.id = Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value);

                        if (departamento.tipo.Equals("C"))
                        {
                            departamento.msn = "Cadastro efetuado com sucesso.";
                        }
                        else
                        {
                            departamento.msn = "Atualização efetuada com sucesso.";
                        }
                    }
                    else
                    {
                        departamento.msn = "Por favor, entre em contato com o Administrador.";
                    }
                }

                return departamento;
            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }

        public TB_DEPARTAMENTO Alterar(TB_DEPARTAMENTO departamento)
        {
            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_update_departamento";
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.Add(new SqlParameter("@id", departamento.id));
                    command.Parameters.Add(new SqlParameter("@nome", departamento.nome));
                    command.Parameters.Add(new SqlParameter("@status", departamento.status));
                    command.Parameters.Add(new SqlParameter("@codigo", departamento.codigo));
                    command.Parameters.Add(new SqlParameter("@tipo", departamento.tipo));
                    command.Parameters.Add(new SqlParameter("@idUsuarioAlt", departamento.idUsuario));
                    Context.Database.OpenConnection();
                    command.ExecuteScalar();

                    departamento.msn = "Cadastro Atualizado com sucesso.";

                }

                return departamento;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

