using CadastroClienteAPI.Models;
using Core.Account;
using Core.DTO;
using Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClienteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IAuthenticate _authenticateService;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IAuthenticate authenticateService, IUsuarioService usuarioService)
        {
            _authenticateService = authenticateService;
            _usuarioService = usuarioService;
        }

        [HttpPost("register")]
        public ActionResult<UserToken> Create(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                return BadRequest("Dados Inválidos");
            }

            var emailExiste = _authenticateService.UserExists(usuarioDTO.Email);

            if (emailExiste)
            {
                return BadRequest("Este email já possui um cadastro");
            }

            var usuario = _usuarioService.Create(usuarioDTO);

            var token = _authenticateService.GenerateToken(usuarioDTO.Id, usuarioDTO.Email);

            return new UserToken
            {
                Token = token
            };
        }

        [HttpPost("login")]
        public ActionResult<UserToken> Login(LoginModel loginModel)
        {
            var existe = _authenticateService.UserExists(loginModel.Email);

            if (!existe)
            {
                return Unauthorized("Usuário não existe");
            }

            var result = _authenticateService.Authenticate(loginModel.Email, loginModel.Senha);

            if (!result)
            {
                return Unauthorized("Usuário ou senha inválidos");
            }

            var usuario = _authenticateService.GetUserByEmail(loginModel.Email);

            var token = _authenticateService.GenerateToken(usuario.Id, usuario.Email);

            return new UserToken
            {
                Token = token
            };
        }
    }
}
