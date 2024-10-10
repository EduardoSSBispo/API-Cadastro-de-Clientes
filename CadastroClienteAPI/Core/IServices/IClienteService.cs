using Core.DTO;
using Core.Entities;

namespace Core.Services
{
    public interface IClienteService
    {
        public int Create(Cliente cliente);

        public void Edit(Cliente cliente);

        public void Delete(int id);

        public ClienteLogradouroDTO? Get(int id);

        public IEnumerable<ClienteLogradouroDTO> GetAll();

        //public IEnumerable<ClienteLogradouroDTO> GetByNome(string nome);
    }
}
