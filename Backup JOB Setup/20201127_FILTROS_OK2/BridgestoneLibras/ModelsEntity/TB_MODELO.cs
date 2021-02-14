using BridgestoneLibras.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_MODELO")]
    public class TB_MODELO : Entity
    {
        public int id_Modelo { get; set; }
        public int id_maquina { get; set; }
        public string nm_modelo { get; set; }
    }
}
