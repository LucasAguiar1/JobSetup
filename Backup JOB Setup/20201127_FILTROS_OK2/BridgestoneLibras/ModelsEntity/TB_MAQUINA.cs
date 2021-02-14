using BridgestoneLibras.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_MAQUINA")]
    public class TB_MAQUINA : Entity
    {
        public int id { get; set; }
        public string tipo { get; set; }
        public int status { get; set; }
        public string nome { get; set; }
        public string idUsuario { get; set; }
        public string dataRegistro { get; set; }

        public int codigo { get; set; }

        public string departamento { get; set; }

        public string msn { get; set; }

        public int id_departamento { get; set; }
    }
}
