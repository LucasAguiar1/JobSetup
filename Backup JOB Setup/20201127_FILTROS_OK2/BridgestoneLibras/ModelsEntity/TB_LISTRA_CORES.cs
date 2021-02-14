using BridgestoneLibras.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_LISTRA_CORES")]
    public class TB_LISTRA_CORES : Entity
    {
        public TB_LISTRA_CORES()
        {
        }
        public string codPlanta { get; set; }
        public string codCor { get; set; }
        public string codCorLocal { get; set; }
        public string dscCorLocal { get; set; }
        public string dscCorEnglish { get; set; }
    }
}
