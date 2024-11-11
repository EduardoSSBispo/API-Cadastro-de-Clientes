using CadastroClienteWeb.Integration.Response;
using CadastroClienteWeb.Model;
using Refit;

namespace CadastroClienteWeb.Integration.Interfaces
{
    public interface IUsuarioIntegration
    {
        Task<TokenResponse> Login(string email, string senha);

        Task<TokenResponse> Register(string nome, string email, string senha);
    }
}
