using BridgestoneLibras.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_ORDEM_FORMULARIO")]
    public class TB_ORDEM_FORMULARIO : Entity
    {
        public int id { get; set; }
        public int id_departamento { get; set; }
        public int id_maquina { get; set; }
        public int id_parteMaquina { get; set; }
        public int orderm_Formulario { get; set; }
        public DateTime dataOrdem { get; set; }
        public string idUsuario { get; set; }

        public int id_Formulario { get; set; }

        public int id_formulario_Filho { get; set; }
        public string tipo { get; set; }
        public int idRetorno { get; set; }

        public string idUsuarioAlt { get; set; }

        public string nome { get; set; }
        public string maquina { get; set; }
        public string parteMaquina { get; set; }

        public string departamento { get; set; }
    }
}
