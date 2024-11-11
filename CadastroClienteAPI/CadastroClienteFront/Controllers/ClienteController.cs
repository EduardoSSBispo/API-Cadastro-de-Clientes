using CadastroClienteWeb.Integration.Interfaces;
using CadastroClienteWeb.Integration.Response;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClienteWeb.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteIntegration _clienteIntegration;
        private int maxNumber = 50;

        public ClienteController(IClienteIntegration clienteIntegration)
        {
            _clienteIntegration = clienteIntegration;
        }


        // GET: ClienteController
        public async Task<ActionResult> Index()
        {
            IEnumerable<ClienteResponse> clientes = await _clienteIntegration.GetAllClientes(1, maxNumber);

            if (clientes == null)
            {
                return BadRequest("Erro");
            }

            return View(clientes);
        }

        // GET: ClienteController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ClienteResponse cliente = await _clienteIntegration.GetCliente(id);

            if (cliente == null)
            {
                return BadRequest("Erro");
            }

            return View(cliente);
        }

        ////GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClienteResponse cliente)
        {
            if (ModelState.IsValid)
            {
                await _clienteIntegration.Create(cliente);
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }

        //// GET: ClienteController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ClienteResponse cliente = await _clienteIntegration.GetCliente(id);

            return View(cliente);
        }

        //// POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ClienteResponse cliente)
        {
            if (ModelState.IsValid)
            {
                await _clienteIntegration.Edit(cliente);
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }

        //// GET: ClienteController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            ClienteResponse cliente = await _clienteIntegration.GetCliente(id);

            return View(cliente);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ClienteResponse cliente)
        {
            await _clienteIntegration.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
