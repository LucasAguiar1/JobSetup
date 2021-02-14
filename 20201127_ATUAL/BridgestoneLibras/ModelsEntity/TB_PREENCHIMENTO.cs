using BridgestoneLibras.Data;
//using LHH.ModelsEntity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_PREENCHIMENTO")]
    public class TB_PREENCHIMENTO : Entity
    {
        public int idPreenchimento { get; set; }
        public int id_formulario { get; set; }
    }
}
