using BridgestoneLibras.Data;
using BridgestoneLibras.Data.Repository;
using BridgestoneLibras.Models;
using BridgestoneLibras.ModelsEntity;
using LHH.Library.Mail;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace LHH.Data.Repository
{
    public class EmailRepository : SpecRepository<BridgestoneLibras.ModelsEntity.Constants>
    {
        public EmailRepository(ApplicationDbSpecContext context) : base(context)
        {
        }

        public static void EnviarMensagemContato(string enviarPara, string titulo, string corpo)
        {
            try
            {

            
            //Conexão Servidor
            SmtpClient smtp = new SmtpClient(Library.Mail.Constants.ServidorSMTP, Library.Mail.Constants.PortaSMTP);
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
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}

