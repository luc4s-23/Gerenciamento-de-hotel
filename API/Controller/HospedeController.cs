using Hoteis.API.Service;
using Microsoft.AspNetCore.Mvc;


namespace Hoteis.API.Controller
{
    [Route("[controller]")]
    public class HospedeController : ControllerBase
    {
        private readonly IHospedeService _hospedeService;
        public HospedeController(IHospedeService hospedeService)
        {
            _hospedeService = hospedeService;
        }

        [HttpGet("listar-todos-registros")]
        public async Task<IActionResult> ListarTodosRegistros()
        {
            var todosRegistros = await _hospedeService.ListarTodosAsync();
            if (todosRegistros == null)
                return NotFound("Nenhum registro encontrado");
            return Ok(todosRegistros);
        }


    }
}