using BridgestoneLibras.Data;
//using LHH.ModelsEntity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_RESPOSTA")]
    public class TB_RESPOSTA : Entity
    {
        public int id_departamento { get; set; }
        public int id_maquina { get; set; }
        public int id_parteMaquina { get; set; }
        public int id_formulario { get; set; }
        public int status { get; set; }
        public string pergunta { get; set; }
        public int id_tipoResposta { get; set; }
        public int id_obrigatorio { get; set; }
        public int ordemApresentacao { get; set; }
        public string formulario { get; set; }
        public string maquina { get; set; }
        public string maquinaParte { get; set; }
        public string departamento { get; set; }
        public string idsAlternativa { get; set; }
        public string valor { get; set; }
        public int idPreenchimento { get; set; }

        public string statusFormulario { get; set; }
        public string DescMutiplaEscolha { get; set; }

        public DateTime dataFim { get; set; }
        public DateTime dataInicio { get; set; }

        public string data { get; set; }

        public int idPai { get; set; }

    }
}
