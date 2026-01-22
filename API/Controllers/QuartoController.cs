using Hoteis.API.DTO;
using Hoteis.API.Model;
using Hoteis.API.Service;
using Microsoft.AspNetCore.Mvc;


namespace Hoteis.API.Controller
{
    [Route("[controller]")]
    public class QuartoController : ControllerBase
    {
        private readonly IQuartoService _service;

        public QuartoController(IQuartoService service)
        {
            _service = service;
        }

        [HttpPost("Novo-Quarto")]
        public async Task<IActionResult> Criar([FromBody] QuartoDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.AdicionarQuartoAsync(dto);
            return Ok(dto);
        }

        [HttpGet("Buscar-todos-os-quartos")]
        public async Task<IEnumerable<Quarto>> ListarQuartos()
        {
            return await _service.ListarAsync();
        }

        [HttpDelete("exclir-quarto{id}")]
        public async Task<IActionResult> ApagarQuarto([FromRoute] int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("O ID do quarto precisa ser válido", nameof(id));
            }
            await _service.DeletarQuartoAsync(id);
            return Ok(id);
        }

        [HttpPut("atualizar-infos{id}")]
        public async Task<IActionResult> AtualizarInfo([FromRoute]int id, [FromBody]QuartoDTO dto)
        {
            if (id <= 0)
            {
                throw new ArgumentException("O ID do quarto precisa ser válido", nameof(id));
            }
            await _service.AtualizarQuartoAsync(id, dto);
            return Ok(dto);
        }
    }
}