using Hoteis.API.DTO;
using Hoteis.API.Model;
using Hoteis.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Hoteis.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly ICategoriaService _service;

        public CategoriaController(
            ICategoriaService service,
            ILogger<CategoriaController> logger
        )
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost("Nova-Categoria")]
        public async Task<IActionResult> Criar([FromBody] CategoriaDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _service.NovaCategoria(dto);
            return Ok(dto);
        }

        [HttpGet("buscar-todas-as-categorias")]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> BuscarTodos()
        {
            var categorias = await _service.GetAll();

            if (!categorias.Any())
            {
                return NotFound();
            }
            var dto = categorias.Select(c => new Categoria
            {
                Id_Categoria = c.Id_Categoria,
                Nome_Categoria = c.Nome_Categoria
            });
            return Ok(dto);
        }
    }
}
