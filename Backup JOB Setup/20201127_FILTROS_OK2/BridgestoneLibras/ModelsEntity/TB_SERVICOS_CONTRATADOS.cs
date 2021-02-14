using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BridgestoneLibras.ModelsEntity
{

    [Table("TB_SERVICOS_CONTRATADOS")]
    public class TB_SERVICOS_CONTRATADOS
    {
        public TB_SERVICOS_CONTRATADOS()
        {
            this.TbServicosContratadosItensPlanilhas = new List<TB_CONTRATOS_ITENS>();
            this.TbServicosContratadosRateioFuncoes = new List<TB_CONTRATOS_FUNCOES>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }
        public DateTime dt_periodo { get; set; }
        [MaxLength(15)]
        public string nr_contrato { get; set; }
        [MaxLength(50)]
        public string ds_descricao { get; set; }
        public int st_conferido { get; set; }
        [MaxLength(500)]
        public string ds_planilha_importada_path { get; set; }
        [MaxLength(200)]
        public string ds_planilha_importada_file { get; set; }
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

        public List<TB_CONTRATOS_ITENS> TbServicosContratadosItensPlanilhas { get; set; }
        public List<TB_CONTRATOS_FUNCOES> TbServicosContratadosRateioFuncoes { get; set; }
    }

}
