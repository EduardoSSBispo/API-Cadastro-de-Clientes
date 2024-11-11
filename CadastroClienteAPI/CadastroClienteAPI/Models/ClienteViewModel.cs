using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CadastroClienteAPI.Models
{
    public class ClienteViewModel
    {
        //[Required]
        // [Key]
        [Display(Name = "Id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [JsonPropertyName("nome")]
        [StringLength(50)]
        public string Nome { get; set; } = null!;

        // [Key]
        // [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50)]
        [Display(Name = "Email")]
        [JsonPropertyName("email")]
        public string Email { get; set; } = null!;

        [Display(Name = "Logotipo")]
        [JsonPropertyName("logotipo")]
        public IFormFile? Logotipo { get; set; }

        [Display(Name = "Logradouros")]
        [JsonPropertyName("logradouros")]
        public IEnumerable<LogradouroViewModel>? ListaLogradouros { get; set; } = null!;
    }
}
