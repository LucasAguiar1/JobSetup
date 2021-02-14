using BridgestoneLibras.ModelsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BridgestoneLibras.Models
{
    public class NotificacaoLiderModel
    {
        public int id_notificacao { get; set; }
        public string ds_operador_notificacao { get; set; }
        public string id_usuario_operador { get; set; }
        public string dt_lider_leitura { get; set; }
        public string dt_operador_envio { get; set; }
        public string ds_lider_notificacao { get; set; }
        public string dt_lider_gravacao { get; set; }
        public string id_usuario_lider { get; set; }
        public string id_formulario { get; set; } //id_lider_email_enviado

        public int id_lider_email_enviado { get; set; }

        public FormularioModel Formulario { get; set; }
        public TB_USUARIO UsuarioOperador { get; set; }
        public TB_USUARIO UsuarioLiderLeitura { get; set; }
        public TB_USUARIO UsuarioLiderNotificacao { get; set; }

        public TB_RESPOSTAFORMULARIO RespostaFormulario { get; set; }


        public NotificacaoLiderModel()
        {
            Formulario = new FormularioModel();
            UsuarioOperador = new TB_USUARIO();
            UsuarioLiderLeitura = new TB_USUARIO();
            UsuarioLiderNotificacao = new TB_USUARIO();
            RespostaFormulario = new TB_RESPOSTAFORMULARIO();
        }

        public static List<NotificacaoLiderModel> Mapper(List<TB_NOTIFICACAOLIDER> lista, bool isExecutadoPorProc)
        {
            var lstRet = new List<NotificacaoLiderModel>();
            for (int i = 0; i < lista.Count; i++)
            {
                if (i == lista.Count - 1)
                {
                    lstRet.Add(Mapper(lista[i], null));
                }
                else
                {
                    lstRet.Add(Mapper(lista[i], lista[i + 1]));
                }
            }

            //Ordernar na procedure
            if (isExecutadoPorProc)
            {
                return lstRet;
            }
            else
            {
                return lstRet.OrderBy(item => item.id_notificacao).ToList();
            }


        }

        private static NotificacaoLiderModel Mapper(TB_NOTIFICACAOLIDER tbNotificacao, object p)
        {
            NotificacaoLiderModel m = new NotificacaoLiderModel();
            m.id_notificacao = tbNotificacao.id_notificacao;

            m.UsuarioOperador.rl_usuario = tbNotificacao.UsuarioOperador.rl_usuario;
            m.UsuarioOperador.nm_usuario = tbNotificacao.UsuarioOperador.nm_usuario;

            m.UsuarioLiderLeitura.rl_usuario = tbNotificacao.UsuarioLiderLeitura.rl_usuario;
            m.UsuarioLiderLeitura.nm_usuario = tbNotificacao.UsuarioLiderLeitura.nm_usuario;

            m.UsuarioLiderNotificacao.rl_usuario = tbNotificacao.UsuarioLiderNotificacao.rl_usuario;
            m.UsuarioLiderNotificacao.nm_usuario = tbNotificacao.UsuarioLiderNotificacao.nm_usuario;

            m.ds_operador_notificacao = tbNotificacao.ds_operador_notificacao;
            m.dt_lider_leitura = tbNotificacao.dt_lider_leitura;
            m.dt_operador_envio = tbNotificacao.dt_operador_envio;
            m.ds_lider_notificacao = tbNotificacao.ds_lider_notificacao;
            m.dt_lider_gravacao = tbNotificacao.dt_lider_gravacao;

            //m.Formulario.id_formulario = tbNotificacao.Formulario.id_formulario;
            //m.Formulario.ds_nome = tbNotificacao.Formulario.ds_nome;

           // m.Formulario.Maquina.departamento.codigo_departamento = tbNotificacao.Formulario.Maquina.departamento.codigo_departamento;
            //m.Formulario.Maquina.departamento.depto = tbNotificacao.Formulario.Maquina.departamento.depto;
           // m.Formulario.Maquina.nm_maquina = tbNotificacao.Formulario.Maquina.nm_maquina;

          //  m.Formulario.MaquinaParte.ds_maquina_parte = tbNotificacao.Formulario.MaquinaParte.ds_maquina_parte;

            m.RespostaFormulario.id_formulario = tbNotificacao.RespostaFormulario.id_formulario_resposta;


            return m;
        }

    }
}
