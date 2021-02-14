using BridgestoneLibras.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_MAQUINAPARTE")]
    public class TB_MAQUINAPARTE : Entity
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string idUsuario { get; set; }
        public int status { get; set; }
        public string dataRegistro { get; set; }
        public string tipo { get; set; }
        public int id_maquina { get; set; }
        public int id_departamento { get; set; }
        public string departamento { get; set; }
        public string maquina { get; set; }

    
    }
}
