using BridgestoneLibras.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_TIPORESPOSTA")]
    public class TB_TIPORESPOSTA : Entity
    {
        public int id { get; set; }
        public string tipoResposta { get; set; }
    }
}
