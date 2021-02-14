using BridgestoneLibras.Data;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_RespPai")]
    public class TB_RespPai : Entity
    {
        public int chave { get; set; }
        public string valor { get; set; }
        public int id { get; set; }
        public int id_tipoResposta { get; set; }
        public int id_obrigatorio { get; set; }
        public string status { get; set; }
        public string idUsuario { get; set; }
        public string nomeUsuario { get; set; }
        public string dataResposta { get; set; }

        public int id_formulario { get; set; }
        public int idRetorno { get; set; }

        public int idPreenchimento { get; set; }

        public string idsAlternativas { get; set; }

        public string identificadoLote { get; set; }
        public List<TB_RespFilho> Filho { get; set; }
        public TB_RespPai()
        {
            Filho = new List<TB_RespFilho>();
        }

    }
}
