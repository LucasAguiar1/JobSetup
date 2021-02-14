using BridgestoneLibras.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_EMAIL")]
    public class Constants : Entity
    {
        //Autenticacao
        public readonly static string Usuario = "";
        public readonly static string Senha = "";

        //Servidor SMTP
        public readonly static string ServidorSMTP = "mailedge.bfusa.com";
        public readonly static int PortaSMTP = 25;

    }
}
