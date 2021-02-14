using BridgestoneLibras.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_DEPARTAMENTO")]
    public class TB_ALTERNATIVAPERGUNTA : Entity
    {
        public int id_alternativa_pergunta { get; set; }
        public string ds_alternativa { get; set; }
        public int id_status { get; set; }
        public int id_pergunta { get; set; }
    }
}
