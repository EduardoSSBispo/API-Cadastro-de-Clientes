using CadastroClienteWeb.Integration.Response;
using Refit;

namespace CadastroClienteWeb.Integration.Refit
{
    public interface IClienteIntegrationRefit
    {
        [Get("/api/Cliente?PageNumber={pageNumber}&PageSize={pageSize}")]
        Task<ApiResponse<IEnumerable<ClienteResponse>>> GetAllClientes(int pageNumber, int pageSize);

        [Get("/api/Cliente/{id}")]
        Task<ClienteResponse> GetCliente(int id);

        [Post("/api/Cliente")]
        [Multipart]
        Task Create([AliasAs("id")] int id,
                [AliasAs("nome")] string nome,
                [AliasAs("email")] string email,
                [AliasAs("logotipo")] StreamPart logotipo = null,
                [AliasAs("logradouros")] string logradourosJson = null);

        [Put("/api/Cliente/{id}")]
        [Multipart]
        Task Edit([AliasAs("id")] int id,
                [AliasAs("nome")] string nome,
                [AliasAs("email")] string email,
                [AliasAs("logotipo")] StreamPart logotipo = null,
                [AliasAs("logradouros")] string logradourosJson = null);

        [Delete("/api/Cliente/{id}")]
        Task Delete(int id);
    }
}
