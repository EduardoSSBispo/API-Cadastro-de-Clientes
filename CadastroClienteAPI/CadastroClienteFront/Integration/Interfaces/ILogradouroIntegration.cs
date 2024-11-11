using CadastroClienteWeb.Integration.Response;

namespace CadastroClienteWeb.Integration.Interfaces
{
    public interface ILogradouroIntegration
    {
        Task<IEnumerable<LogradouroResponse>> GetAllLogradouros(int pageNumber, int pageSize);

        Task<LogradouroResponse> GetLogradouro(int id);

        Task Create(LogradouroResponse logradouro);

        Task Edit(LogradouroResponse logradouro);

        Task Delete(int id);
    }
}
