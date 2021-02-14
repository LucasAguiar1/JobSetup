using BridgestoneLibras.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_SETOR")]
    public class TB_SETOR : Entity
    {
        public String Descricao { get; set; }
        public int IdSetor { get; set; }

        public List<int> tipoSetor { get; set; }

        


    }
}
