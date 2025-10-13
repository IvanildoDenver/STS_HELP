using System.ComponentModel.DataAnnotations;

namespace STS_HELP.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o E-mail do Usuário")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Digite a Senha do Usuário")]
        public string Senha { get; set; } = "";


    }
}
