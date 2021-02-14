using BridgestoneLibras.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_STATUS")]

    public class TB_STATUS : Entity
    {
        public int id { get; set; }
        public string status { get; set; }
    }
}
