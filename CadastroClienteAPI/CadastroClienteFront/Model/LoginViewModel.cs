using System.ComponentModel.DataAnnotations;

namespace CadastroClienteWeb.Model
{
    public class LoginViewModel
    {
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
