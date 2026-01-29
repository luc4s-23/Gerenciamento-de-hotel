using Hoteis.API.DTO;
using Hoteis.API.Model;
using Hoteis.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Hoteis.API.Controllers
{
    [Route("[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _service;

        public ReservaController(IReservaService service)
        {
            _service = service;
        }

        [HttpPost("Nova-reserva/{Quarto_ID_FK}")]
        public async Task<IActionResult> NovaReservaAsync([FromBody] ReservaDTO dto, [FromRoute] int Quarto_ID_FK)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.ReservarQuartoAsync(dto, Quarto_ID_FK);
            return Ok(dto);
        }

        [HttpGet("Buscar-reservas")]
        public async Task<List<ReservaReadDTO>> BuscarTodosAsync()
        {
            return await _service.BuscarTodosAsync();
        }
        [HttpGet("buscar-por-id{id}")]
        public async Task<IActionResult> BuscarPorIdAsync(int id)
        {
            var ReservaID = await _service.BuscarPorIdAsync(id);
            return Ok(ReservaID);
        }
        [HttpPut("atualizar-reserva{id}")]
        public async Task<IActionResult> AtualizarReserva(int Id, ReservaDTO dto)
        {
            var AtualizarReserva = await _service.AtualizarAsync(Id, dto);
            return Ok(AtualizarReserva);
        }

    }
}