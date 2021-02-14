using BridgestoneLibras.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_RESPOSTAFORMULARIO")]
    public class TB_RESPOSTAFORMULARIO : Entity
    {
        public int id_formulario_resposta { get; set; }
        public int id_formulario { get; set; }
        public int id_usuario { get; set; }
        public int id_situacao_formulario { get; set; }

        public TB_RESPOSTAFORMULARIO()
        {

        }
    }
}
