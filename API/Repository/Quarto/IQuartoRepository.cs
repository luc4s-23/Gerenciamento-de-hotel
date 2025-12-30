using Hoteis.API.Model;

namespace Hoteis.API.Repository
{
    public interface IQuartoRepository
    {
        Task<IEnumerable<Quarto>> ListarTodosAsync();
        Task<Quarto?> BuscarPorIdAsync(int id);
        Task<Quarto?> BuscarPorNumero(string Numero_quarto);
        Task AdicionarAsync(Quarto quarto);
        Task AtualizarAsync(Quarto quarto);
        Task RemoverAsync(int id);
    }
}