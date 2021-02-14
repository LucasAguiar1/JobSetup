using BridgestoneLibras.ModelsEntity;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;

namespace BridgestoneLibras.Data.Repository
{
    public class SegurancaRepository : Repository<TB_LOGIN>
    {
        public SegurancaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public UsuarioModel ValidaUsuario(string login, string senha,
                                  bool ativoAD, string principalAD, string secundarioAD,
                                  ref string permissoes, ref bool validoAD, ref string usuario, ref int departamento)
        {
            bool valido = false;
            validoAD = false;
            permissoes = string.Empty;
            usuario = string.Empty;
            
            UsuarioModel usuarioModel = new UsuarioModel();
            try
            {
                if (ativoAD)
                {
                    valido = ValidaUsuarioAD(login, senha, principalAD);

                    if ((!valido) && (!String.IsNullOrEmpty(secundarioAD)))
                    {
                        valido = ValidaUsuarioAD(login, senha, secundarioAD);
                    }
                }

                validoAD = valido;
                //valido = ValidaUsuarioISAC(login, senha, valido, ref permissoes, ref usuario);
                usuarioModel = ValidaUsuarioISAC(login, senha, valido, ref permissoes, ref usuario, ref departamento);

            }
            catch
            {
                valido = false;
            }

            return usuarioModel;
            //return valido;

            
        }

        public bool ValidaUsuarioAD(string usuario, string senha, string domain)
        {
            try
            {
                using (var adContext = new PrincipalContext(ContextType.Domain, domain))
                {
                    return adContext.ValidateCredentials(usuario, senha);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UsuarioModel ValidaUsuarioISAC(string login, string senha, bool validoAD, ref string permissoes, ref string usuario, ref int departamento)
        {
            bool valido = false;
            UsuarioModel usuarioModel = new UsuarioModel();
            int count = 0;
            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_login_validar";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@login", login));
                    command.Parameters.Add(new SqlParameter("@senha", senha));
                    //command.Parameters.Add(new SqlParameter("@validoAD", 0));
                    //command.Parameters.Add(new SqlParameter("@usuario", usuario));
                    //command.Parameters.Add(new SqlParameter("@valido", valido));
                    //command.Parameters.Add(new SqlParameter("@permissoes", permissoes));

                    Context.Database.OpenConnection();
                    command.ExecuteNonQuery();



                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                if (count == 0)
                                {



                                    usuarioModel.rl_usuario = Convert.ToInt32(result["RL"].ToString());
                                    usuarioModel.nm_usuario = result["Nome"].ToString();
                                    usuarioModel.valido = string.IsNullOrEmpty(result["Valido"].ToString()) ? 2 : Convert.ToInt32(result["Valido"].ToString());
                                    usuarioModel.id_departamento = Convert.ToInt32(result["Departamento"].ToString());
                                    usuarioModel.Funcao = result["Funcao"].ToString();
                                    usuarioModel.idUsuario = result["usuario"].ToString();



                                    usuario = result["usuario"].ToString();
                                    valido = result["Valido"].ToString() == "1" ? true : false;
                                    permissoes = usuarioModel.Funcao;
                                    departamento = Convert.ToInt32(result["Departamento"].ToString());

                                    count++;
                                }

                                UsuarioFuncao funcao = new UsuarioFuncao();
                                funcao.funcao = result["Funcao"].ToString();

                                usuarioModel.lUsuarioFuncao.Add(funcao);

                            }
                        }
                    }





                    //usuario = command.Parameters[3].Value.ToString();
                    //valido = Convert.ToBoolean(command.Parameters[4].Value.ToString());
                    //permissoes = command.Parameters[5].Value.ToString();

                    //Context.Database.OpenConnection();
                    //using (var result = command.ExecuteReader())
                    //{
                    //    if (result.HasRows)
                    //    {
                    //        while (result.Read())
                    //        {
                    //            if (count == 0)
                    //            {
                    //                usuarioModel.rl_usuario = Convert.ToInt32(result["RL"].ToString());
                    //                usuarioModel.nm_usuario = result["Nome"].ToString();
                    //                usuarioModel.valido = string.IsNullOrEmpty(result["Valido"].ToString()) ? 2 :  Convert.ToInt32(result["Valido"].ToString());
                    //                usuarioModel.id_departamento = Convert.ToInt32(result["Departamento"].ToString());

                    //                valido = true;
                    //                count++;
                    //            }

                    //            UsuarioFuncao funcao = new UsuarioFuncao();
                    //            funcao.funcao = result["Funcao"].ToString();

                    //            usuarioModel.lUsuarioFuncao.Add(funcao);

                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                //valido = false;
                return usuarioModel;

            }

            return usuarioModel;
            //return valido;
        }

        public bool LogProcessoInclusao(string tabela, string tipo, int chave, string usuario, string descricao)
        {
            bool retorno = false;

            try
            {
                using (var command = Context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "sp_log_processo_incluir";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@tabela", tabela));
                    command.Parameters.Add(new SqlParameter("@tipo", tipo));
                    command.Parameters.Add(new SqlParameter("@chave", chave));
                    command.Parameters.Add(new SqlParameter("@usuario", usuario));
                    command.Parameters.Add(new SqlParameter("@descricao", descricao));

                    Context.Database.OpenConnection();
                    command.ExecuteNonQuery();
                }

                retorno = true;
            }
            catch
            {
                retorno = false;
            }

            return retorno;
        }
    }
}
