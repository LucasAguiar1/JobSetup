using BridgestoneLibras.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_FORMULARIO")]
    public class TB_NOTIFICACAOLIDER : Entity
    {
        public int id_notificacao { get; set; }
        public string ds_operador_notificacao { get; set; }
        public string dt_lider_leitura { get; set; }
        public string dt_operador_envio { get; set; }
        public string ds_lider_notificacao { get; set; }
        public string dt_lider_gravacao { get; set; }

        public TB_USUARIO UsuarioOperador { get; set; }
        public TB_USUARIO UsuarioLiderLeitura { get; set; }
        public TB_USUARIO UsuarioLiderNotificacao { get; set; }

        public TB_FORMULARIO Formulario { get; set; }
        public TB_RESPOSTAFORMULARIO RespostaFormulario { get; set; }

        public TB_NOTIFICACAOLIDER()
        {
            Formulario = new TB_FORMULARIO();
            UsuarioOperador = new TB_USUARIO();
            UsuarioLiderLeitura = new TB_USUARIO();
            UsuarioLiderNotificacao = new TB_USUARIO();
            RespostaFormulario = new TB_RESPOSTAFORMULARIO();
        }
    }
}
