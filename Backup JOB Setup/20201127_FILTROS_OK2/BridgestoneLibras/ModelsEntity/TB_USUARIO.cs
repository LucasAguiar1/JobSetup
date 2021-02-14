using BridgestoneLibras.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_FORMULARIO")]
    public class TB_USUARIO : Entity
    {
        public int rl_usuario { get; set; }
        public string nm_usuario { get; set; }
        public string ds_login { get; set; }
        public string ds_senha { get; set; }
        public int id_departamento { get; set; }
        public int valido { get; set; }
        public string email { get; set; }

        public TB_DEPARTAMENTO Departamento { get; set; }

        public List<UsuarioFuncao> lUsuarioFuncao { get; set; }

        public TB_USUARIO()
        {
            lUsuarioFuncao = new List<UsuarioFuncao>();
            Departamento = new TB_DEPARTAMENTO();
        }
    }
}
