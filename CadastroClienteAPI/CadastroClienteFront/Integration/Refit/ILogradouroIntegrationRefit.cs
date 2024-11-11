using CadastroClienteWeb.Integration.Response;
using Refit;

namespace CadastroClienteWeb.Integration.Refit
{
    public interface ILogradouroIntegrationRefit
    {
        [Get("/api/Logradouro?PageNumber={pageNumber}&PageSize={pageSize}")]
        Task<ApiResponse<IEnumerable<LogradouroResponse>>> GetAllLogradouro(int pageNumber, int pageSize);

        [Get("/api/Logradouro/{id}")]
        Task<LogradouroResponse> GetLogradouro(int id);

        [Post("/api/Logradouro/")]
        Task Create(LogradouroResponse Logradouro);

        [Put("/api/Logradouro/{logradouro.id}")]
        Task Edit(LogradouroResponse logradouro);

        [Delete("/api/Logradouro/{id}")]
        Task Delete(int id);
    }
}
