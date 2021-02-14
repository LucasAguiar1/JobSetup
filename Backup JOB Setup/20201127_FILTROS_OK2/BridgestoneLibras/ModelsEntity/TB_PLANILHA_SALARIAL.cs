using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BridgestoneLibras.ModelsEntity
{

    [Table("TB_PLANILHA_SALARIAL")]
    public class TB_PLANILHA_SALARIAL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }
        public decimal cd_funcao_id { get; set; }
        public DateTime dt_vigencia { get; set; }
        public decimal vl_horario { get; set; }
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

        [ForeignKey("id")]
        public TB_FUNCOES CdFuncao { get; set; }
    }

}
