using BridgestoneLibras.Models;
using System.Collections.Generic;
using System.Linq;

namespace BridgestoneLibras.ModelsEntity
{
    public class UsuarioModel
    {
        public int rl_usuario { get; set; }
        public string nm_usuario { get; set; }
        public string ds_login { get; set; }
        public string ds_senha { get; set; }
        public string idUsuario { get; set; }
        public int id_departamento { get; set; }
        public int valido { get; set; }

        public string Funcao { get; set; }
        public string email { get; set; }
        

        public List<UsuarioFuncao> lUsuarioFuncao { get; set; }

        public UsuarioModel()
        {
            lUsuarioFuncao = new List<UsuarioFuncao>();
            
        }

        public static List<UsuarioModel> Mapper(List<TB_USUARIO> lista, bool isExecutadoPorProc)
        {
            var lstRet = new List<UsuarioModel>();
            for (int i = 0; i < lista.Count; i++)
            {
                if (i == lista.Count - 1)
                {
                    lstRet.Add(Mapper(lista[i], null));
                }
                else
                {
                    lstRet.Add(Mapper(lista[i], lista[i + 1]));
                }
            }

            //Ordernar na procedure
            if (isExecutadoPorProc)
            {
                return lstRet;
            }
            else
            {
                return lstRet.OrderBy(item => item.rl_usuario).ToList();
            }


        }

        private static UsuarioModel Mapper(TB_USUARIO tbUsuario, object p)
        {
            UsuarioModel u = new UsuarioModel();

            u.rl_usuario = tbUsuario.rl_usuario;
            u.nm_usuario = tbUsuario.nm_usuario;
            u.ds_login = tbUsuario.ds_login;
            u.ds_senha = tbUsuario.ds_senha;
            u.id_departamento = tbUsuario.id_departamento;
            u.valido = tbUsuario.valido;

            foreach (var item in tbUsuario.lUsuarioFuncao)
            {
                UsuarioFuncao f = new UsuarioFuncao();
                f.funcao = item.funcao;
                u.lUsuarioFuncao.Add(f);
            }
            
            return u;
        }
    }
}
