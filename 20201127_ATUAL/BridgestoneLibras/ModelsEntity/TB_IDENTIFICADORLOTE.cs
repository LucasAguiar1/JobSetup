using BridgestoneLibras.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_IDENTIFICADORLOTE")]
    public class TB_IDENTIFICADORLOTE : Entity
    {
        public string vc_identificador_lote1 { get; set; }
        public int id_maquina { get; set; }
        public int id { get; set; }

        public int idPreenchimento { get; set; }
        public string identificadoLote { get; set; }

    }
}
