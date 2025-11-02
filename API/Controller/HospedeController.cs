using Hoteis.API.Model;
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

        [HttpPost("novo-hospede")]
        public async Task<IActionResult> NovoRegistro(HospedeDTO dto)
        {
            var resultado = await _hospedeService.ValidarHospedeAsync(hospede);

            return resultado.Status switch
            {
                200 => Ok(resultado.MensagemOuObjeto),
                400 => BadRequest(resultado.MensagemOuObjeto),
                409 => Conflict(resultado.MensagemOuObjeto),
                _ => StatusCode(500, "Erro inesperado.")
            };

            if (dto == null)
            {
                return BadRequest();
            }
            var NovoRegistro = new Hospede
            {
                Nome_hospede = dto.Nome_hospede,
                Email_hospede = dto.Email_hospede,
                CPF_hospede = dto.CPF_hospede,
                Telefone_hospede = dto.Telefone_hospede,
                Menor_idade = dto.Menor_idade
            };
            await _hospedeService.AdicionarHospedeAsync(NovoRegistro);
            return Ok(NovoRegistro);
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