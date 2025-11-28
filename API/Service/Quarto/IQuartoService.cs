// 1. Defina um alias (apelido) para a classe Quarto do Model
using Hoteis.API.DTO; // Este using ainda é útil se você tiver outros tipos aqui.

// 2. Seu namespace permanece o mesmo para manter a organização
namespace Hoteis.API.Service.Quarto
{
    public interface IQuartoService
    {
        // 3. Use o alias 'QuartoModel' em vez do nome conflitante 'Quarto'
        Task AdicionarQuartoAsync(QuartoDTO quartoDTO);
        Task ValidarInfosQuarto(QuartoDTO quartoDTO);

    }
}