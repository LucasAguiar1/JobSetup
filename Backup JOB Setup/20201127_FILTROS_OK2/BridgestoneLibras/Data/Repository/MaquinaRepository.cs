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
    public class MaquinaRepository : SpecRepository<TB_MAQUINA>
    {
        public MaquinaRepository(ApplicationDbSpecContext context) : base(context)
        {

        }

        public List<TB_MAQUINA> Consultar()
        {
            try
            {
                List<TB_MAQUINA> lMaquina = new List<TB_MAQUINA>();
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_maquinas";

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@id_departamento", DBNull.Value));

                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {

                            while (result.Read())
                            {
                                TB_MAQUINA tbMaquina = new TB_MAQUINA();
                                tbMaquina.id = Convert.ToInt32(result["id"].ToString());
                                tbMaquina.nome = result["nome"].ToString();
                                tbMaquina.status = Convert.ToInt32(result["status"].ToString());
                                tbMaquina.tipo = result["tipo"].ToString().Trim();
                                tbMaquina.idUsuario = result["idUsuario"].ToString().Trim();
                                tbMaquina.dataRegistro = result["dataRegistro"].ToString().Trim();
                                tbMaquina.codigo = Convert.ToInt32(result["codigo"].ToString());
                                tbMaquina.departamento = result["departamento"].ToString().Trim();
                                tbMaquina.id_departamento = Convert.ToInt32(result["id_departamento"].ToString());
                                lMaquina.Add(tbMaquina);
                            }
                        }
                    }
                }

                return lMaquina;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<TB_MAQUINA> Consultar(TB_MAQUINA maquina)
        {
            try
            {
                List<TB_MAQUINA> lMaquina = new List<TB_MAQUINA>();
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_maquinas";
                    command.CommandType = CommandType.StoredProcedure;

                    if (maquina.id_departamento == 0)
                    {
                        command.Parameters.Add(new SqlParameter("@id_departamento", null));
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("@id_departamento", maquina.id_departamento));
                    }


                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {

                            while (result.Read())
                            {
                                TB_MAQUINA tbMaquina = new TB_MAQUINA();
                                tbMaquina.id = Convert.ToInt32(result["id"].ToString());
                                tbMaquina.nome = result["nome"].ToString();
                                tbMaquina.status = Convert.ToInt32(result["status"].ToString());
                                tbMaquina.tipo = result["tipo"].ToString().Trim();
                                tbMaquina.idUsuario = result["idUsuario"].ToString().Trim();
                                tbMaquina.dataRegistro = result["dataRegistro"].ToString().Trim();
                                tbMaquina.codigo = Convert.ToInt32(result["codigo"].ToString());
                                tbMaquina.departamento = result["departamento"].ToString().Trim();
                                tbMaquina.id_departamento = Convert.ToInt32(result["id_departamento"].ToString());
                                lMaquina.Add(tbMaquina);
                            }
                        }
                    }
                }

                return lMaquina;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //
        public TB_MAQUINA Alterar(TB_MAQUINA maquina)
        {

            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {

                    command.CommandText = "sp_update_maquina";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@idUsuarioAlt", maquina.idUsuario));
                    command.Parameters.Add(new SqlParameter("@id_departamento", maquina.id_departamento));
                    command.Parameters.Add(new SqlParameter("@nome", maquina.nome));
                    command.Parameters.Add(new SqlParameter("@tipo", maquina.tipo));
                    command.Parameters.Add(new SqlParameter("@status", maquina.status));
                    command.Parameters.Add(new SqlParameter("@id", maquina.id));

                    Context.Database.OpenConnection();
                    command.ExecuteScalar();

                    maquina.msn = "Atualização efetuada com sucesso.";

                }

                return maquina;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public TB_MAQUINA Cadastrar(TB_MAQUINA maquina)
        {


            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {

                    command.CommandText = "sp_insert_maquina";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@idUsuario", maquina.idUsuario));
                    command.Parameters.Add(new SqlParameter("@id_departamento", maquina.id_departamento));
                    command.Parameters.Add(new SqlParameter("@nome", maquina.nome));
                    command.Parameters.Add(new SqlParameter("@tipo", maquina.tipo));
                    command.Parameters.Add(new SqlParameter("@status", maquina.status));
                    command.Parameters.Add(new SqlParameter("@idRetorno", maquina.id) { Size = 200, Direction = ParameterDirection.Output });

                    Context.Database.OpenConnection();
                    command.ExecuteScalar();

                    if (Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value) != 0)
                    {
                        maquina.id = Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value);

                        if (maquina.tipo.Equals("C"))
                        {
                            maquina.msn = "Cadastro efetuado com sucesso.";
                        }
                        else
                        {
                            maquina.msn = "Atualização efetuada com sucesso.";
                        }
                    }
                    else
                    {
                        maquina.msn = "Por favor, entre em contato com o Administrador.";
                    }
                }

                return maquina;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public List<SelectListItem> Combo(List<TB_MAQUINA> lMaquina, string opcaoInicial)
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

            foreach (var Linha in lMaquina)
            {
                lista.Add(new SelectListItem()
                {
                    Value = Linha.id.ToString(),
                    Text = Linha.nome
                });
            }

            return lista;
        }

        public MaquinaModel UpdateMaquina(MaquinaModel model)
        {
            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {

                    command.CommandText = "sp_update_maquina";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@id_maquina", model.id_maquina));
                    command.Parameters.Add(new SqlParameter("@nm_maquina", model.nm_maquina));
                    command.Parameters.Add(new SqlParameter("@id_status", model.id_status));
                    command.Parameters.Add(new SqlParameter("@id_departamento", model.id_departamento));

                    command.Parameters.Add(new SqlParameter("@idRetorno", model.id_maquina) { Size = 200, Direction = ParameterDirection.Output });

                    Context.Database.OpenConnection();
                    command.ExecuteNonQuery();

                    if (Convert.ToInt32(command.Parameters[0].Value) != 0)
                    {
                        model.id_maquina = Convert.ToInt32(command.Parameters[0].Value.ToString());
                    }

                }

                return model;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

