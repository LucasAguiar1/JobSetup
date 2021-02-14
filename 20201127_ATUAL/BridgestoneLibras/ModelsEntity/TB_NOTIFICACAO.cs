using BridgestoneLibras.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_NOTIFICACAO")]
    public class TB_NOTIFICACAO : Entity
    {
        public int id { get; set; }
        public int id_formulario { get; set; }
        public string id_lider { get; set; }
        public string notificacao { get; set; }

        public string observacaoLider { get; set; }
        public string dataNotificacao { get; set; }
        public string dataLeitura { get; set; }
        public string dataObsLider { get; set; }

        public string id_usuario { get; set; }

        public string id_nomeOperador { get; set; }

        public string formulario { get; set; }
        public string maquina { get; set; }
        public string maquinaParte { get; set; }

        public int result { get; set; }
        public string nomeLider { get; set; }

        public int respondidas { get; set; }

        public string id_liderObs { get; set; }

        public int id_departamento { get; set; }

        public string Departamento { get; set; }

        public string permissao { get; set; }
    }
}
