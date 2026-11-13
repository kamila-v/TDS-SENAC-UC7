using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pousada.API.Data;
using Pousada.API.Models;

namespace Pousada.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicosController : ControllerBase
    {
        AppDbContext _dbContext;

        public ServicosController(AppDbContext context) //por que nao é servicosController ?
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Servicos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var servicoBuscado = _dbContext.Servicos.FirstOrDefault(s => s.Id == id);

            if (servicoBuscado == null)
            {
                return NotFound($"Serviço buscado por id {id} não encontrado");
            }

            return Ok(servicoBuscado);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Servico novoServico)
        {
            if(novoServico == null || string.IsNullOrWhiteSpace(novoServico.Nome))
            {
                return BadRequest("Informe um serviço de hospedagem válido");
            }

            _dbContext.Servicos.Add(novoServico);
            _dbContext.SaveChanges();

            return Ok("Criado");
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] int id)
        {
            var capturaServicoDaLista = _dbContext.Servicos.FirstOrDefault(s => s.Id == id);

            if (capturaServicoDaLista != null)
                _dbContext.Servicos.Remove(capturaServicoDaLista);

            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
