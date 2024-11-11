using System.Text.Json.Serialization;

namespace CadastroClienteWeb.Integration.Response
{
    public class LogradouroResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("clienteId")]
        public int ClienteId { get; set; }
    }
}
