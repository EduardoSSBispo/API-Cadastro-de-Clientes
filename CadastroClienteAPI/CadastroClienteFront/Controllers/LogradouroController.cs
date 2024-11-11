using CadastroClienteWeb.Integration.Interfaces;
using CadastroClienteWeb.Integration.Response;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClienteWeb.Controllers
{
    public class LogradouroController : Controller
    {
        private readonly ILogradouroIntegration _logradouroIntegration;
        private int maxNumber = 50;

        public LogradouroController(ILogradouroIntegration logradouroIntegration)
        {
            _logradouroIntegration = logradouroIntegration;
        }


        // GET: LogradouroController
        public async Task<ActionResult> Index()
        {
            IEnumerable<LogradouroResponse> logradouros = await _logradouroIntegration.GetAllLogradouros(1, maxNumber);

            if (logradouros == null)
            {
                return BadRequest("Erro");
            }

            return View(logradouros);
        }

        // GET: LogradouroController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            LogradouroResponse logradouro = await _logradouroIntegration.GetLogradouro(id);

            if (logradouro == null)
            {
                return BadRequest("Erro");
            }

            return View(logradouro);
        }

        ////GET: LogradouroController/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: LogradouroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LogradouroResponse logradouro)
        {
            if (ModelState.IsValid)
            {
                await _logradouroIntegration.Create(logradouro);
                return RedirectToAction(nameof(Index));
            }

            return View(logradouro);
        }

        //// GET: LogradouroController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            LogradouroResponse logradouro = await _logradouroIntegration.GetLogradouro(id);

            return View(logradouro);
        }

        //// POST: LogradouroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, LogradouroResponse logradouro)
        {
            if (ModelState.IsValid)
            {
                await _logradouroIntegration.Edit(logradouro);
                return RedirectToAction(nameof(Index));
            }

            return View(logradouro);
        }

        //// GET: LogradouroController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            LogradouroResponse logradouro = await _logradouroIntegration.GetLogradouro(id);

            return View(logradouro);
        }

        // POST: LogradouroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, LogradouroResponse logradouro)
        {
            await _logradouroIntegration.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
