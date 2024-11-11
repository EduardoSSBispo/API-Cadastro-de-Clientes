using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CadastroClienteWeb.Integration.Response
{
    public class ClienteResponse
    {

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

        [JsonPropertyName("logotipo")]
        public byte[]? Logotipo { get; set; }

        [JsonPropertyName("logradouros")]
        public IEnumerable<LogradouroResponse>? ListaLogradouros { get; set; } = null!;
    }
}
