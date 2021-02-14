using BridgestoneLibras.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{

    [Table("TB_MENSAGENS")]
    public class TB_MENSAGENS : Entity
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(50)]
        public string tipo { get; set; }

        [MaxLength(500)]
        public string mensagem { get; set; }
    }

}
