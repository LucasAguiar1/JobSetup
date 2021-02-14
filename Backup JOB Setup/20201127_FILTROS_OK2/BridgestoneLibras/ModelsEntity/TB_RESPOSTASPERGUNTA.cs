using BridgestoneLibras.Data;
using BridgestoneLibras.ModelsEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LHH.ModelsEntity
{
    [Table("TB_DEPARTAMENTO")]
    public class TB_RESPOSTASPERGUNTA : Entity
    {
        public int id_respostas { get; set; }
        public int id_formulario { get; set; }
        public int id_pergunta { get; set; }
        public string ds_resposta { get; set; }

        public TB_RESPOSTAFORMULARIO RespostasFormulario { get; set; }

        public TB_RESPOSTASPERGUNTA()
        {
            RespostasFormulario = new TB_RESPOSTAFORMULARIO();
        }
    }

    
}
