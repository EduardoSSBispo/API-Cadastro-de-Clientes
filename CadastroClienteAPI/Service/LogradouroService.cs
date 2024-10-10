using Core.Entities;
using Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class LogradouroService : ILogradouroService
    {
        private readonly CadastroContext _context;

        public LogradouroService(CadastroContext context)
        {
            _context = context;
        }

        public int Create(IEnumerable<Logradouro> logradouros, Cliente cliente)
        {
            foreach (var logradouro in logradouros)
            {
                logradouro.ClienteId = cliente.Id;
                _context.Add(logradouro);
            }

            _context.SaveChanges();

            return cliente.Id;

        }

        public int Create(Logradouro logradouro)
        {
            _context.Add(logradouro);
            _context.SaveChanges();

            return logradouro.Id;
        }

        public void DeleteAllFromCliente(int ClienteId)
        {
            var logradouro = _context.Logradouro.Find(ClienteId);
            _context.Logradouro.Remove(logradouro);

            _context.SaveChanges();
        }

        public void Edit(IEnumerable<Logradouro> logradouros)
        {
            foreach (var logradouro in logradouros)
            {
                _context.Logradouro.Update(logradouro);
            }

            _context.SaveChanges();
        }

        public void Edit(Logradouro logradouro)
        {
            _context.Logradouro.Update(logradouro);
        }

        public Logradouro Get(int id)
        {
            return _context.Logradouro.Find(id);
        }

        public IEnumerable<Logradouro?> GetAll()
        {
            return _context.Logradouro.AsNoTracking();
        }

        public IEnumerable<Logradouro?> GetAllFromCliente(int ClienteId)
        {
            var query = from logradouro in _context.Logradouro
                        where logradouro.ClienteId == ClienteId
                        select logradouro;

            return query.AsNoTracking();
        }
        public void Delete(int id)
        {
            var logradouro = _context.Logradouro.Find(id);

            _context.Logradouro.Remove(logradouro);

            _context.SaveChanges();
        }
    }
}
