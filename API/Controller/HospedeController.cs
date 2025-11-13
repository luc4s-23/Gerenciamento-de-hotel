using Hoteis.API.DTO;
using Hoteis.API.Model;
using Hoteis.API.Service;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpPost("adicionar-novo-hospede")]
        public async Task<IActionResult> AddHospede(HospedeDTO dto)
        {
            if(dto == null)
            {
                return NotFound();
            }
            var novoHospede = new Hospede
            {
                Nome_hospede = dto.Nome_hospede,
                CPF_hospede = dto.CPF_hospede,
                Email_hospede = dto.Email_hospede,
                Telefone_hospede = dto.Telefone_hospede,
                Menor_idade = dto.Menor_idade
            };
            
            var (Status, Dados) = await _hospedeService.AdicionarHospedeAsync(novoHospede);
            return StatusCode(Status, Dados);
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