using BridgestoneLibras.Data;
//using LHH.ModelsEntity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_PERGUNTA")]
    public class TB_PERGUNTA : Entity
    {
        
        public TB_PERGUNTA()
        {
            listDescricaoMultiplaEscolha = new List<TB_DescricaoMultiplaEscolha>();
            listFilhos = new List<TB_FILHO>();
            

        }

        public List<TB_DescricaoMultiplaEscolha> listDescricaoMultiplaEscolha { get; set; }

        public List<TB_FILHO> listFilhos { get; set; }

        

        public int id { get; set; }
        public int id_formulario { get; set; }
        public int status { get; set; }
        public string nome { get; set; }
        public int id_tipoResposta { get; set; }
        public int id_obrigatorio { get; set; }
        public int id_tess { get; set; }
        public string ordemApresentacao { get; set; }
        public string dataRegistro { get; set; }
        public string idUsuario { get; set; }
        public string tipo { get; set; }

        public string formulario { get; set; }
        public string resposta { get; set; }

        public string descTess { get; set; }
        public string descObrigatorio { get; set; }

        public int id_departamento { get; set; }
        public int id_maquina { get; set; }
        public int id_parteMaquina { get; set; }

        public string maquina { get; set; }
        public string maquinaParte { get; set; }
        public string departamento { get; set; }

        public string idPai { get; set; }

        public string idsAlternativa { get; set; }

        public string nomeFormulario { get; set; }

        public string valor { get; set; }

        public int chave { get; set; }


        public string i_Pk_Maquina   { get; set; }
        public string vc_Descripcion { get; set; }
        public string codigoTess { get; set; }


        public int idpreenchimento { get; set; }
        public string identificadorLote { get; set; }


    }
}
