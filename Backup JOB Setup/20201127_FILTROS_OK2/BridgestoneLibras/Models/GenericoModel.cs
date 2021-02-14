using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BridgestoneLibras.Models
{
    public class GenericoModel
    {
        public int SituacaoStatus { get; set; }
        public DateTime DataInclusao { get; set; }
        public string CodigoInclusaoUsuario { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string CodigoAlteracaoUsuario { get; set; }
        public DateTime DataExclusao { get; set; }
        public string CodigoExclusaoUsuario { get; set; }
    }
}
