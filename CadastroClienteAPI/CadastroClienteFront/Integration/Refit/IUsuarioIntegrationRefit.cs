using CadastroClienteWeb.Integration.Response;
using CadastroClienteWeb.Model;
using Refit;

namespace CadastroClienteWeb.Integration.Refit
{
    public interface IUsuarioIntegrationRefit
    {
        [Post("/api/Usuario/login")]
        Task<TokenResponse> Login([Body] LoginViewModel model);

        [Post("/api/Usuario/register")]
        Task<TokenResponse> Register([Body] LoginViewModel model);
    }
}
