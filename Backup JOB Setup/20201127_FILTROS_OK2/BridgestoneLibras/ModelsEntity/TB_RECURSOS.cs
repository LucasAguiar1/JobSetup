using BridgestoneLibras.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BridgestoneLibras.ModelsEntity
{

    [Table("TB_RECURSOS")]
    public class TB_RECURSOS : Entity
    {
        public TB_RECURSOS()
        {
         
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [MaxLength(15)]
        public string cd_rl { get; set; }
        [MaxLength(150)]
        public string nm_recurso { get; set; }
        public int qt_dias_experiencia { get; set; }
        public int st_remover_dos_calculos { get; set; }
        [MaxLength(30)]
        public string ds_rh_status { get; set; }
        [MaxLength(10)]
        public string ds_rh_regime_trabalho { get; set; }
        [MaxLength(50)]
        public string ds_rh_cargo { get; set; }
        [MaxLength(50)]
        public string ds_escala { get; set; }
        public DateTime dt_entrada_area_tecnica { get; set; }

        public int cd_cc_id { get; set; }
        public int cd_funcao_id { get; set; }
        public int? st_status { get; set; }

        [ForeignKey("id")]
      
       
     

        [NotMapped]
        public string horasTrab { get; set; }
        [NotMapped]
        public string horasTransf { get; set; }
        [NotMapped]
        public string horasExc { get; set; }
        [NotMapped]
        public string partRel { get; set; }
        [NotMapped]
        public DateTime periodo { get; set; }
        [NotMapped]
        public int id_periodo_recurso { get; set; }
    }

}
