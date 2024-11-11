using CadastroClienteWeb.Integration.Interfaces;
using CadastroClienteWeb.Integration.Refit;
using CadastroClienteWeb.Integration.Response;
using Newtonsoft.Json;
using Refit;

namespace CadastroClienteWeb.Integration
{
    public class ClienteIntegration : IClienteIntegration
    {
        private readonly IClienteIntegrationRefit _clienteIntegrationRefit;

        public ClienteIntegration(IClienteIntegrationRefit clienteIntegrationRefit)
        {
            _clienteIntegrationRefit = clienteIntegrationRefit;
        }

        public async Task Create(ClienteResponse cliente)
        {

            var logradourosJson = JsonConvert.SerializeObject(cliente.ListaLogradouros);

            var logotipoStream = cliente.Logotipo != null
                ? new StreamPart(new MemoryStream(cliente.Logotipo), "logotipo.jpg")
                : null;

            await _clienteIntegrationRefit.Create(
                cliente.Id,
                cliente.Nome,
                cliente.Email,
                logotipoStream,
                logradourosJson);
        }

        public async Task Delete(int id)
        {
            await _clienteIntegrationRefit.Delete(id);
        }

        public async Task Edit(ClienteResponse cliente)
        {
            var logradourosJson = JsonConvert.SerializeObject(cliente.ListaLogradouros);

            var logotipoStream = cliente.Logotipo != null
                ? new StreamPart(new MemoryStream(cliente.Logotipo), "logotipo.jpg")
                : null;

            await _clienteIntegrationRefit.Edit(
                cliente.Id,
                cliente.Nome,
                cliente.Email,
                logotipoStream,
                logradourosJson);
        }

        public async Task<IEnumerable<ClienteResponse>> GetAllClientes(int pageNumber, int pageSize)
        {
            var clientes = await _clienteIntegrationRefit.GetAllClientes(pageNumber, pageSize);

            if (clientes != null && clientes.IsSuccessStatusCode)
            {
                return clientes.Content;
            }

            return null;
        }

        public async Task<ClienteResponse> GetCliente(int id)
        {
            var cliente = await _clienteIntegrationRefit.GetCliente(id);

            if (cliente != null)
            {
                return cliente;
            }

            return null;
        }
    }
}
