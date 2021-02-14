using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BridgestoneLibras.Models
{
    public class LoginModel
    {
        public int Id { get; set; }

        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "Informe o nome do usuário")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Senha { get; set; }
    }
}
