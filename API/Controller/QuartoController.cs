using Hoteis.API.DTO;
using Hoteis.API.Model;
using Hoteis.API.Service;
using Microsoft.AspNetCore.Mvc;


namespace Hoteis.API.Controller
{
    [Route("[controller]")]
    public class QuartoController : ControllerBase
    {
        private readonly ICategoriaService _service;

        [HttpPost]
        public async Task<IActionResult> Criar(CategoriaDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _service.NovaCategoria(dto);
            return Ok(dto);
        }
    }
}