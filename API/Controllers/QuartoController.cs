using Hoteis.API.DTO;
using Hoteis.API.Model;
using Hoteis.API.Service;
using Hoteis.API.Service.Quarto;
using Microsoft.AspNetCore.Mvc;


namespace Hoteis.API.Controller
{
    [Route("[controller]")]
    public class QuartoController : ControllerBase
    {
        private readonly IQuartoService _service;

        private QuartoController(IQuartoService service)
        {
            _service = service;
        }

        [HttpPost("Novo-Quarto")]
        public async Task<IActionResult> Criar([FromBody]QuartoDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _service.AdicionarQuartoAsync(dto);
            return Ok(dto);
        }
    }
}