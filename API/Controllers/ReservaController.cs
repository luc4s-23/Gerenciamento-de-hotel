using Hoteis.API.DTO;
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

        [HttpPost("Nova-reserva")]
        public async Task<IActionResult> NovaReservaAsync([FromBody] ReservaDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.CreateAsync(dto);
            return Ok(dto);
        }

    }
}