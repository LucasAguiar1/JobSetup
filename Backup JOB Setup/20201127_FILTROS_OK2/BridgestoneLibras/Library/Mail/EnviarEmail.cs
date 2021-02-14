using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LHH.Library.Mail
{
    public class EnviarEmail
    {

        public static void EnviarMensagemContato(string enviarPara, string titulo, string corpo)
        {
            //Conexão Servidor
            SmtpClient smtp = new SmtpClient(Constants.ServidorSMTP, Constants.PortaSMTP);
            smtp.EnableSsl = false;                                                 //É o que faz a obrigatoriedade da autenticação.
            smtp.UseDefaultCredentials = false;                                     //Auxilia a SSL na autenticação default.

            //Criando a mensagem
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("noreply-br@la-bridgestone.com");       // e-mail origem
            mensagem.To.Add(new MailAddress(enviarPara));                           //envia para
            mensagem.Subject = titulo;                                              // titulo
            mensagem.Body = corpo;                                                  //CORPO
            mensagem.IsBodyHtml = true;                                             //Habilitando o envio do conteudo por HTML.
            mensagem.Priority = MailPriority.Normal;                                //Prioridade

            smtp.Send(mensagem);

        }
    }
}
