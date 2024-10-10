using AutoMapper;
using CadastroClienteAPI.Models;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClienteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LogradouroController : ControllerBase
    {
        private readonly ILogradouroService _logradouroService;
        private readonly IMapper _mapper;

        public LogradouroController(IMapper mapper, ILogradouroService logradouroService)
        {
            _mapper = mapper;
            _logradouroService = logradouroService;
        }

        // GET: LogradouroController
        [HttpGet]
        public ActionResult Get()
        {
            var listaClientes = _logradouroService.GetAll();

            if (listaClientes == null)
                return NotFound();

            return Ok(listaClientes);
        }

        // GET: LogradouroController/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Logradouro logradouro = _logradouroService.Get(id);

            if (logradouro == null)
                return NotFound();

            return Ok(logradouro);
        }

        // POST api/<LogradouroController>
        [HttpPost]
        public ActionResult Post([FromBody] LogradouroViewModel logradouroModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var logradouro = _mapper.Map<Logradouro>(logradouroModel);

            _logradouroService.Create(logradouro);

            return CreatedAtAction(nameof(Get), new { id = logradouro.Id }, logradouro);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] LogradouroViewModel logradouroModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var logradouro = _mapper.Map<Logradouro>(logradouroModel);

            logradouro.Id = id;

            if (logradouro == null)
                return NotFound();

            _logradouroService.Edit(logradouro);

            return Ok();
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Logradouro logradouro = _logradouroService.Get(id);

            if (logradouro == null)
                return NotFound();

            _logradouroService.Delete(id);
            return Ok();
        }
    }
}
