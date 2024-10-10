using Core.Entities;

namespace Core.DTO
{
    public partial class ClienteLogradouroDTO
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public string Email { get; set; } = null!;

        public byte[] Logotipo { get; set; }

        public IEnumerable<Logradouro> Logradouros { get; set; }
    }
}
