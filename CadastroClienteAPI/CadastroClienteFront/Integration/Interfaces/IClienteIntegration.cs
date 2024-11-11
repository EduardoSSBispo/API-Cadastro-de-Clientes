using CadastroClienteWeb.Integration.Response;

namespace CadastroClienteWeb.Integration.Interfaces
{
    public interface IClienteIntegration
    {
        Task<IEnumerable<ClienteResponse>> GetAllClientes(int pageNumber, int pageSize);

        Task<ClienteResponse> GetCliente(int id);

        Task Create(ClienteResponse cliente);

        Task Edit(ClienteResponse cliente);

        Task Delete(int id);
    }
}
