using AutoMapper;
using CadastroClienteAPI.Models;
using Core.DTO;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClienteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly ILogradouroService _logradouroService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper, ILogradouroService logradouroService)
        {
            _clienteService = clienteService;
            _mapper = mapper;
            _logradouroService = logradouroService;
        }


        // GET: ClienteController
        [HttpGet]
        public ActionResult Get()
        {
            var listaClientes = _clienteService.GetAll();

            if (listaClientes == null)
                return NotFound();

            return Ok(listaClientes);
        }

        // GET: ClienteController/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            ClienteLogradouroDTO clienteDto = _clienteService.Get(id);

            if (clienteDto == null)
                return NotFound();

            return Ok(clienteDto);
        }

        // POST api/<ClientesController>
        [HttpPost]
        public ActionResult Post([FromForm] ClienteViewModel clienteModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var cliente = _mapper.Map<Cliente>(clienteModel);

            if (clienteModel.Logotipo != null)
            {
                using var memoryStream = new MemoryStream();
                clienteModel.Logotipo.CopyTo(memoryStream);
                cliente.Logotipo = memoryStream.ToArray();  // Armazena a imagem como byte[]
            }

            _clienteService.Create(cliente);

            var logradouros = _mapper.Map<IEnumerable<Logradouro>>(clienteModel.ListaLogradouros);

            _logradouroService.Create(logradouros, cliente);

            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromForm] ClienteViewModel clienteModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var cliente = _mapper.Map<Cliente>(clienteModel);

            if (clienteModel.Logotipo != null)
            {
                using var memoryStream = new MemoryStream();
                clienteModel.Logotipo.CopyTo(memoryStream);
                cliente.Logotipo = memoryStream.ToArray();  // Armazena a imagem como byte[]
            }

            var logradouro = _mapper.Map<IEnumerable<Logradouro>>(clienteModel.ListaLogradouros);

            cliente.Id = id;

            if (cliente == null)
                return NotFound();

            _clienteService.Edit(cliente);

            _logradouroService.Edit(logradouro);

            return Ok();
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            ClienteLogradouroDTO clienteDto = _clienteService.Get(id);

            if (clienteDto == null)
                return NotFound();

            _clienteService.Delete(id);
            return Ok();
        }
    }
}
