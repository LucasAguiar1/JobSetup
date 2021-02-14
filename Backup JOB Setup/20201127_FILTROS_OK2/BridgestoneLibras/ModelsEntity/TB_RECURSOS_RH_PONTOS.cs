using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BridgestoneLibras.ModelsEntity
{

    [Table("TB_RECURSOS_RH_PONTOS")]
    public class TB_RECURSOS_RH_PONTOS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int cd_recurso_id { get; set; }
        public DateTime dt_referencia { get; set; }
        public decimal qt_horas { get; set; }
        public int? st_status { get; set; }

        [ForeignKey("id")]
        public TB_RECURSOS CdRecurso { get; set; }
    }

}
