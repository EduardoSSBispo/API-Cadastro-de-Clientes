namespace Core.Entities
{
    public class Logradouro
    {
        public int Id { get; set; }

        public string? Nome { get; set; } = null!;

        public int ClienteId { get; set; }
    }
}
