using BridgestoneLibras.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("OPERADOR")]
    public class OPERADOR : Entity
    {
        public string id { get; set; }
        public string valor { get; set; }
    
    }
}
