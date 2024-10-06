using System.ComponentModel.DataAnnotations;

namespace CadastroClienteAPI.Models
{
    public class ClienteViewModel
    {
        [Display(Name = "Nome")]
        [StringLength(50)]
        public string nome { get; set; } = null!;

        [Display(Name = "Email")]
        [StringLength(50)]
        [Key]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string email { get; set; } = null!;
    }
}
