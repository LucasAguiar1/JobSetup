using BridgestoneLibras.Data;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_FILHO")]
    public class TB_FILHO : Entity
    {

        public TB_FILHO()
        {
            listDescricaoMultiplaEscolha = new List<TB_DescricaoMultiplaEscolha>();
            
        }

        public List<TB_DescricaoMultiplaEscolha> listDescricaoMultiplaEscolha { get; set; }
        public int id { get; set; }
        public int id_perguntaPai { get; set; }
        public string dataRegistro { get; set; }
        public string tipo { get; set; }
        public string idUsuario { get; set; }
        public string nome { get; set; }

        public int id_filho { get; set; }



        public int id_obrigatorio { get; set; }
        public string descObrigatorio { get; set; }
        public int id_tess { get; set; }
        public string descTess { get; set; }
        public int id_tipoResposta { get; set; }
        public int status { get; set; }
        public string resposta { get; set; }
        public string maquina { get; set; }
        public string maquinaParte { get; set; }
        public string departamento { get; set; }

        public string idsAlternativa { get; set; }

        public int idPai { get; set; }
        public int id_formulario { get; set; }

        public int idPreenchimento { get; set; }

        public string DescMutiplaEscolha { get; set; }
        public string valor { get; set; }

        public int chave { get; set; }

        public string nomePergunta { get; set; }

    }
}
