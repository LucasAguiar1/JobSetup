using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BridgestoneLibras.Models
{
    public class AlternativaPerguntaModel
    {
        public int id_alternativa_pergunta { get; set; }
        public string ds_alternativa { get; set; }
        public int id_status { get; set; }
        public int id_pergunta { get; set; }
    }
}
