using BridgestoneLibras.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_MAQUINAPCS")]
    public class TB_MAQUINAPCS : Entity
    {
        public int i_Pk_Maquina { get; set; }
        public string vc_Descripcion { get; set; }
      
    }
}
