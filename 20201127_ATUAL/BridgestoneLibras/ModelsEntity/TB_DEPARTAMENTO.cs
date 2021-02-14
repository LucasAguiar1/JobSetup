using BridgestoneLibras.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_DEPARTAMENTO")]
    public class TB_DEPARTAMENTO : Entity
    {
        public int id { get; set; }
        public string  nome { get; set; }
        public int status { get; set; }
        public string codigo { get; set; }

        public string idUsuario { get; set; }
        public string tipo { get; set; }

        public string msn { get; set; }
       


    }
}
