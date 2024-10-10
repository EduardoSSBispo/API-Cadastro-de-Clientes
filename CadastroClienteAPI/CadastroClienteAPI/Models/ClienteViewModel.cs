using System.ComponentModel.DataAnnotations;

namespace CadastroClienteAPI.Models
{
    public class ClienteViewModel
    {
        [Required]
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [StringLength(50)]
        public string Nome { get; set; } = null!;

        [Display(Name = "Email")]
        [StringLength(50)]
        [Key]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Email { get; set; } = null!;

        [Display(Name = "Logotipo")]
        public IFormFile? Logotipo { get; set; }


        [Display(Name = "Logradouros")]
        public IEnumerable<LogradouroViewModel>? ListaLogradouros { get; set; } = null!;
    }
}
