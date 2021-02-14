using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BridgestoneLibras.Models
{
    public class RespostasFormularioModel
    {
        public int id_formulario_resposta { get; set; }
        public string id_formulario { get; set; }
        public int id_usuario { get; set; }
        public string id_situacao_formulario { get; set; }

        public RespostasFormularioModel()
        {
            
        }
    }
}
