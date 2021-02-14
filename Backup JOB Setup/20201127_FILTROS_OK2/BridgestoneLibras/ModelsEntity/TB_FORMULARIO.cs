using BridgestoneLibras.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_FORMULARIO")]
    public class TB_FORMULARIO : Entity
    {
      
        public int id { get; set; }
        public int id_maquina { get; set; }
        public int id_parteMaquina { get; set; }
        public string nome { get; set; }
        public int status { get; set; }
        public string tipo { get; set; }
        public string idUsuario { get; set; }
        public string dataRegistro { get; set; }

        public string maquina { get; set; }
        public string parteMaquina { get; set; }

        public string departamento { get; set; }

        public int id_departamento { get; set; }
    }
}
