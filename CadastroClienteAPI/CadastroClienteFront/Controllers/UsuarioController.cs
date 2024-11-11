using CadastroClienteWeb.Integration.Interfaces;
using CadastroClienteWeb.Model;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClienteWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioIntegration _usuarioIntegration;

        public UsuarioController(IUsuarioIntegration usuarioIntegration)
        {
            _usuarioIntegration = usuarioIntegration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            var token = await _usuarioIntegration.Login(model.Email, model.Senha);

            if (token != null && !string.IsNullOrEmpty(token.Token))
            {
                // Armazene o token em um cookie
                HttpContext.Session.SetString("JwtToken", token.Token);

                return RedirectToAction("Index", "Home"); // Redireciona após login bem-sucedido
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel model)
        {

            var token = await _usuarioIntegration.Register(model.Nome ,model.Email, model.Senha);

            if (token != null && !string.IsNullOrEmpty(token.Token))
            {
                // Armazene o token em um cookie
                HttpContext.Session.SetString("JwtToken", token.Token);

                return RedirectToAction("Index", "Home"); // Redireciona após login bem-sucedido
            }

            return View(model);
        }
    }
}
