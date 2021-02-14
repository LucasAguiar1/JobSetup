using BridgestoneLibras.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_DescricaoMultiplaEscolha")]
    public class TB_DescricaoMultiplaEscolha : Entity
    {
        public int id { get; set; }
        public string  nome { get; set; }
        public int status { get; set; }
        public int id_TipoResposta { get; set; }

        public string idUsuario { get; set; }
        public string tipo { get; set; }

        public string msn { get; set; }
       


    }
}
