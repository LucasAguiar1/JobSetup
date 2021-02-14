using BridgestoneLibras.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_STATUS_FORMULARIO")]

    public class TB_STATUS_FORMULARIO : Entity
    {
        public int id { get; set; }
        public string status { get; set; }

        public string descricao { get; set; }
    }
}
