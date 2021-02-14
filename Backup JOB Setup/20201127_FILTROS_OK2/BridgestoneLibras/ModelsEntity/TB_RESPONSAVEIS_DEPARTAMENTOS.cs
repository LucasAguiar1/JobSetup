using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BridgestoneLibras.ModelsEntity
{

    [Table("TB_RESPONSAVEIS_DEPARTAMENTOS")]
    public class TB_RESPONSAVEIS_DEPARTAMENTOS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }
        public decimal cd_cc_id { get; set; }
        [MaxLength(100)]
        public string nm_responsavel { get; set; }
        [MaxLength(100)]
        public string ds_responsavel_email { get; set; }
        [MaxLength(100)]
        public string nm_coordenador { get; set; }
        [MaxLength(100)]
        public string ds_coordenadoremail { get; set; }
        public int? st_status { get; set; }
        public DateTime? dt_inclusao { get; set; }
        [MaxLength(50)]
        public string cd_inclusao_usuario { get; set; }
        public DateTime? dt_alteracao { get; set; }
        [MaxLength(50)]
        public string cd_alteracao_usuario { get; set; }
        public DateTime? dt_exclusao { get; set; }
        [MaxLength(50)]
        public string cd_exclusao_usuario { get; set; }

        //[ForeignKey("id")]
        //public TB_CENTROCUSTO CdCc { get; set; }
    }

}
