using BridgestoneLibras.Data;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_RespFilho")]
    public class TB_RespFilho : Entity
    {

        public int id { get; set; }
        public int idPai { get; set; }
        public int id_tipoResposta { get; set; }
        public string valor { get; set; }
        public int id_obrigatorio { get; set; }

        public int idRetorno { get; set; }

        public int chave { get; set; }

        public string idUsuario { get; set; }
        public string nomeUsuario { get; set; }

        public int idPreenchimento { get; set; }

        public string idsAlternativa { get; set; }
    }
}
