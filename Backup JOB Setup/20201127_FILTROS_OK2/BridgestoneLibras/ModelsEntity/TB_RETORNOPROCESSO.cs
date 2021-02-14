using BridgestoneLibras.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_RETORNOPROCESSO")]
    public class TB_RETORNOPROCESSO : Entity
    {
        public string Capa { get; set; }
        public string Base { get; set; }
        public string Codigo { get; set; }
    
    }
}
