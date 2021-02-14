using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BridgestoneLibras.Models
{
    public class RespostasPerguntaModel
    {
        public string id_respostas { get; set; }
        public string id_formulario { get; set; }
        public string id_pergunta_pai { get; set; }
        public string id_pergunta { get; set; }
        public string ds_resposta { get; set; }    

        public RespostasFormularioModel RespostasFormulario { get; set; }

        public RespostasPerguntaModel()
        {
            RespostasFormulario = new RespostasFormularioModel();
        }


    }
}
