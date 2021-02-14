using BridgestoneLibras.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{

    [Table("TB_LOGIN")]
    public class TB_LOGIN : Entity
    {
        public TB_LOGIN()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }
        [MaxLength(15)]
        public string usuario { get; set; }
        [MaxLength(150)]
        public string senha { get; set; }
    }

}
