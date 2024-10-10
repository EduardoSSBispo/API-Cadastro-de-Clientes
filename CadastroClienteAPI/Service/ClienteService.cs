using Core.DTO;
using Core.Entities;
using Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class ClienteService : IClienteService
    {
        private readonly CadastroContext _context;
        private readonly ILogradouroService _logradouroService;

        public ClienteService(CadastroContext context, ILogradouroService logradouroService)
        {
            _context = context;
            _logradouroService = logradouroService;
        }

        public int Create(Cliente cliente)
        {
            _context.Add(cliente);

            _context.SaveChanges();

            return cliente.Id;
        }

        public void Delete(int id)
        {
            var cliente = _context.Cliente.Find(id);
            _context.Cliente.Remove(cliente);

            _context.SaveChanges();
        }

        public void Edit(Cliente cliente)
        {
            _context.Update(cliente);
            _context.SaveChanges();
        }

        public ClienteLogradouroDTO? Get(int id)
        {
            var cliente = _context.Cliente
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);

            if (cliente == null) return null;

            var logradouros = _logradouroService.GetAllFromCliente(id);

            return new ClienteLogradouroDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Logotipo = cliente.Logotipo != null
                    ? cliente.Logotipo.Take(10).ToArray()
                    : Array.Empty<byte>(),
                Logradouros = logradouros
            };
        }

        public IEnumerable<ClienteLogradouroDTO> GetAll()
        {
            var clientes = _context.Cliente.AsNoTracking().ToList();

            var clienteLogradouros = clientes.Select(cliente => new ClienteLogradouroDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Logotipo = cliente.Logotipo != null
                    ? cliente.Logotipo.Take(10).ToArray()
                    : Array.Empty<byte>(),
                Logradouros = _logradouroService.GetAllFromCliente(cliente.Id)
            });

            return clienteLogradouros;
        }
    }
}
