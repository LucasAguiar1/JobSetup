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
using System.Threading.Tasks;

namespace LHH.Data.Repository
{
    public class MaquinaParteRepository : SpecRepository<TB_MAQUINAPARTE>
    {
        public MaquinaParteRepository(ApplicationDbSpecContext context) : base(context)
        {
        }

        public List<TB_MAQUINAPARTE> Consultar(TB_MAQUINAPARTE parte)
        {
            try
            {
                List<TB_MAQUINAPARTE> lMaquinaParte = new List<TB_MAQUINAPARTE>();
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_consulta_maquinaparte";
                    command.CommandType = CommandType.StoredProcedure;

                    if (parte.id_maquina == 0)
                    {
                        command.Parameters.Add(new SqlParameter("@id_parteMaquina", null));
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("@id_parteMaquina", parte.id_maquina));
                    }

                    Context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                TB_MAQUINAPARTE maquinaParte = new TB_MAQUINAPARTE();
                                maquinaParte.id = Convert.ToInt32(result["id"].ToString());
                                maquinaParte.idUsuario = result["idUsuario"].ToString();
                                maquinaParte.id_departamento = Convert.ToInt32(result["id_departamento"].ToString());
                                maquinaParte.id_maquina = Convert.ToInt32(result["id_maquina"].ToString());
                                maquinaParte.maquina = result["maquina"].ToString();
                                maquinaParte.nome = result["nome"].ToString();

                                maquinaParte.status = Convert.ToInt32(result["status"].ToString());
                                maquinaParte.tipo = result["tipo"].ToString();
                                maquinaParte.departamento = result["departamento"].ToString();
                                maquinaParte.dataRegistro = result["dataRegistro"].ToString();


                                lMaquinaParte.Add(maquinaParte);
                            }
                        }
                    }
                }
                return lMaquinaParte;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public TB_MAQUINAPARTE Alterar(TB_MAQUINAPARTE parteMaquina)
        {

            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {

                    command.CommandText = "sp_update_maquinaparte";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@status", parteMaquina.status));
                    command.Parameters.Add(new SqlParameter("@idUsuarioAlt", parteMaquina.idUsuario));
                    command.Parameters.Add(new SqlParameter("@id_departamento", parteMaquina.id_departamento));
                    command.Parameters.Add(new SqlParameter("@id_maquina", parteMaquina.id_maquina));
                    command.Parameters.Add(new SqlParameter("@nome", parteMaquina.nome));
                    command.Parameters.Add(new SqlParameter("@tipo", parteMaquina.tipo));
                    command.Parameters.Add(new SqlParameter("@id", parteMaquina.id));

                    Context.Database.OpenConnection();
                    command.ExecuteScalar();


                    parteMaquina.msn = "Cadastro atualizado com sucesso.";

                }

                return parteMaquina;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public TB_MAQUINAPARTE Cadastrar(TB_MAQUINAPARTE parteMaquina)
        {

            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {

                    command.CommandText = "sp_insert_maquinaparte";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@status", parteMaquina.status));
                    command.Parameters.Add(new SqlParameter("@idUsuario", parteMaquina.idUsuario));
                    command.Parameters.Add(new SqlParameter("@id_departamento", parteMaquina.id_departamento));
                    command.Parameters.Add(new SqlParameter("@id_maquina", parteMaquina.id_maquina));
                    command.Parameters.Add(new SqlParameter("@nome", parteMaquina.nome));
                    command.Parameters.Add(new SqlParameter("@tipo", parteMaquina.tipo));
                    command.Parameters.Add(new SqlParameter("@idRetorno", parteMaquina.id) { Size = 200, Direction = ParameterDirection.Output });

                    Context.Database.OpenConnection();
                    command.ExecuteScalar();

                    if (Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value) != 0)
                    {
                        parteMaquina.id = Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value);

                        if (parteMaquina.tipo.Equals("C"))
                        {
                            parteMaquina.msn = "Cadastro efetuado com sucesso.";
                        }
                        else
                        {
                            parteMaquina.msn = "Atualização efetuada com sucesso.";
                        }
                    }
                    else
                    {
                        parteMaquina.msn = "Por favor, entre em contato com o Administrador.";
                    }
                }

                return parteMaquina;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public List<SelectListItem> Combo(List<TB_MAQUINAPARTE> lparte, string opcaoInicial)
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

        //public MaquinaParteModel UpdateParteMaquina(MaquinaParteModel maquinaParteModel)
        //{
        //    try
        //    {
        //        using (var command = Context.Database.GetDbConnection().CreateCommand())
        //        {

        //            command.CommandText = "sp_update_maquinaparte";
        //            command.CommandType = CommandType.StoredProcedure;

        //            command.Parameters.Add(new SqlParameter("@id_maquina_parte", maquinaParteModel.id_maquina_parte));
        //            command.Parameters.Add(new SqlParameter("@id_status", maquinaParteModel.id_status));
        //            command.Parameters.Add(new SqlParameter("@id_maquina", maquinaParteModel.id_maquina));
        //            command.Parameters.Add(new SqlParameter("@ds_maquina_parte", maquinaParteModel.ds_maquina_parte));
        //            command.Parameters.Add(new SqlParameter("@idRetorno", maquinaParteModel.id_maquina) { Size = 200, Direction = ParameterDirection.Output });

        //            Context.Database.OpenConnection();
        //            command.ExecuteNonQuery();

        //            if (Convert.ToInt32(command.Parameters[0].Value) != 0)
        //            {
        //                maquinaParteModel.id_maquina = Convert.ToInt32(command.Parameters[0].Value.ToString());
        //            }
        //        }

        //        return maquinaParteModel;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
    }
}
