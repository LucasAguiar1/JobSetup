using BridgestoneLibras.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{

    [Table("TB_PERIODOS")]
    public class TB_PERIODOS : Entity
    {
        public TB_PERIODOS()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_periodo { get; set; }
        public DateTime dt_competencia { get; set; }
        public DateTime dt_inicio { get; set; }
        public DateTime dt_fim { get; set; }
        public decimal nr_dia_bridge { get; set; }
        public decimal vl_peso_ajustado { get; set; }
        public int id_situacao { get; set; }
        [MaxLength(30)]
        [NotMapped]
        public string nm_situacao { get; set; }
    }
}