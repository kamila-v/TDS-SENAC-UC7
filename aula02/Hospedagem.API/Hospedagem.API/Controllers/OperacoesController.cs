using Hospedagem.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospedagem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacoesController : ControllerBase
    {
        [HttpPost]
        public IActionResult SimularEntrada([FromBody] RequisicaoEntrada entrada)
        {
            if (entrada == null || string.IsNullOrEmpty(entrada.NomeProduto))
            {
                return BadRequest("Dados de entrada necessários ou nome ausente.");
            }

            if(entrada.Quantidade <= 0 || (entrada.PrecoCusto <= 0))
            {
                return BadRequest("Quantidade e preço devem ser maiores que 0!");            
            } 

            RequisicaoEntrada novaRequisicao = new RequisicaoEntrada();

            return Ok(novaRequisicao);
        }
    }
}
