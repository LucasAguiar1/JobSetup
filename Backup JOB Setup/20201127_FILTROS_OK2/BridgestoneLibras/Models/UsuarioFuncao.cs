using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BridgestoneLibras.ModelsEntity
{
    public class UsuarioFuncao
    {

        public string funcao { get; set; }


        public UsuarioFuncao()
        {
        }

        

        private static UsuarioFuncao Mapper(UsuarioFuncao tbUsuario, object p)
        {
            UsuarioFuncao u = new UsuarioFuncao();

            u.funcao = tbUsuario.funcao;
          

            return u;
        }
    }
}
