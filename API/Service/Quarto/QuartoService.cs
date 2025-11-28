using Hoteis.API.DTO;
using Hoteis.API.Repository;


namespace Hoteis.API.Service.Quarto
{
    public class QuartoService : IQuartoService
    {
        private readonly IQuartoRepository _quartoRepository;
        public async Task AdicionarQuartoAsync(QuartoDTO dto)
        {
        }

        public async Task ValidarInfosQuarto(QuartoDTO dto)
        {
            var novoQuarto = await _quartoRepository.BuscarPorNumero(dto.Numero_quarto);
            if (novoQuarto != null)
            {
                throw new Exception($"O número de quartos '{dto.Numero_quarto}, já está em uso, por favor, use outro!'");
            }
            //var categoriaExistente = await _quartoRepository.
        }
    }
}