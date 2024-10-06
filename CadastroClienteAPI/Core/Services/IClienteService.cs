using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IClienteService
    {
        public int Create(Cliente cliente);

        public void Edit(Cliente cliente);

        public void Delete(int id);

        public Cliente? Get(int id);

        public IEnumerable<Cliente> GetAll();

        public IEnumerable<Cliente> GetByNome(string nome);
    }
}
