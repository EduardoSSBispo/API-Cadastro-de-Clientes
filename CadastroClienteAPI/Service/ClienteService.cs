using Core;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public  class ClienteService : IClienteService
    {
        private readonly CadastroContext _context;

        public ClienteService(CadastroContext context)
        {
            _context = context;
        }

        public int Create(Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();

            return cliente.id;
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
        public Cliente? Get(int id)
        {
            return _context.Cliente.Find(id);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _context.Cliente.AsNoTracking();
        }

        public IEnumerable<Cliente> GetByNome(string nome)
        {
            return (IEnumerable<Cliente>)_context.Cliente.Where(
                cliente => cliente.nome.StartsWith(nome)).AsNoTracking();
        }
    }
}
