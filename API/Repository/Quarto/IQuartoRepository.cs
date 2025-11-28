
using System.Collections;
using Hoteis.API.Model;

namespace Hoteis.API.Repository
{
    public interface IQuartoRepository
    {
        Task<IList> ListarTodosAsync();
        Task<Quarto?> BuscarPorIdAsync(int id);
        Task<Quarto?> BuscarPorNumero(int Numero_quarto);
        Task AdicionarAsync(Quarto quarto);
        Task AtualizarAsync(Quarto quarto);
        Task RemoverAsync(int id);
    }
}