using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hoteis.API.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        [HttpGet("listar-todos")]
        public async Task<IActionResult> ListarTodos()
        {
            var lista = await _hospedeService.ListarTodosAsync();
            if (lista != null || !lista.Any())
            {
                return NotFound("Nenhum registro encontrado");
            }
            return Ok(lista);
        }


    }
}