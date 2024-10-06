using AutoMapper;
using CadastroClienteAPI.Models;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClienteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
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

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Cliente cliente = _clienteService.Get(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        // POST api/<ClientesController>
        [HttpPost]
        public ActionResult Post([FromBody] ClienteViewModel clienteModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var cliente = _mapper.Map<Cliente>(clienteModel);
            _clienteService.Create(cliente);

            return Ok();
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ClienteViewModel clienteModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var cliente = _mapper.Map<Cliente>(clienteModel);
            cliente.id = id;

            if (cliente == null)
                return NotFound();

            _clienteService.Edit(cliente);

            return Ok();
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Cliente cliente = _clienteService.Get(id);

            if (cliente == null)
                return NotFound();

            _clienteService.Delete(id);
            return Ok();
        }
    }
}
