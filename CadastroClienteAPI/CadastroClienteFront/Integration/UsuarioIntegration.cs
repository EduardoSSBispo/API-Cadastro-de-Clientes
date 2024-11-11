using CadastroClienteWeb.Integration.Interfaces;
using CadastroClienteWeb.Integration.Refit;
using CadastroClienteWeb.Integration.Response;
using CadastroClienteWeb.Model;

namespace CadastroClienteWeb.Integration
{
    public class UsuarioIntegration : IUsuarioIntegration
    {
        private readonly IUsuarioIntegrationRefit _usuarioIntegration;

        public UsuarioIntegration(IUsuarioIntegrationRefit usuarioIntegration)
        {
            _usuarioIntegration = usuarioIntegration;
        }

        public async Task<TokenResponse> Login(string email, string senha)
        {
            var loginModel = new LoginViewModel { Email = email, Senha = senha };
            var token = await _usuarioIntegration.Login(loginModel);
            return token;
        }

        public async Task<TokenResponse> Register(string nome, string email, string senha)
        {
            var loginModel = new LoginViewModel { Nome = nome, Email = email, Senha = senha };
            var token = await _usuarioIntegration.Register(loginModel);
            return token;
        }
    }
}
