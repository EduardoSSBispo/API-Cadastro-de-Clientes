using CadastroClienteWeb.Integration.Interfaces;
using CadastroClienteWeb.Integration.Refit;
using CadastroClienteWeb.Integration.Response;

namespace CadastroClienteWeb.Integration
{
    public class LogradouroIntegration : ILogradouroIntegration
    {
        private readonly ILogradouroIntegrationRefit _logradouroIntegrationRefit;

        public LogradouroIntegration(ILogradouroIntegrationRefit logradouroIntegrationRefit)
        {
            _logradouroIntegrationRefit = logradouroIntegrationRefit;
        }

        public async Task Create(LogradouroResponse logradouro)
        {
            await _logradouroIntegrationRefit.Create(logradouro);
        }

        public async Task Delete(int id)
        {
            await _logradouroIntegrationRefit.Delete(id);
        }

        public async Task Edit(LogradouroResponse logradouro)
        {
            await _logradouroIntegrationRefit.Edit(logradouro);
        }

        public async Task<IEnumerable<LogradouroResponse>> GetAllLogradouros(int pageNumber, int pageSize)
        {
            var logradouros = await _logradouroIntegrationRefit.GetAllLogradouro(pageNumber, pageSize);

            if (logradouros != null && logradouros.IsSuccessStatusCode)
            {
                return logradouros.Content;
            }

            return null;
        }

        public async Task<LogradouroResponse> GetLogradouro(int id)
        {
            var logradouros = await _logradouroIntegrationRefit.GetLogradouro(id);

            if (logradouros != null)
            {
                return logradouros;
            }

            return null;
        }
    }
}
