using Core.DTO;
using Core.Entities;
using Core.Pagination;

namespace Core.Services
{
    public interface IClienteService
    {
        public int Create(Cliente cliente);

        public void Edit(Cliente cliente);

        public void Delete(int id);

        public ClienteLogradouroDTO? Get(int id);

        public PagedList<ClienteLogradouroDTO> GetAll(int pageNumber, int pageSize);
    }
}
