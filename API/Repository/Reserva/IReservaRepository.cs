using Hoteis.API.DTO;
using Hoteis.API.Model;

namespace Hoteis.API.Repository
{
    public interface IReservaRepository
    {
        Task<IEnumerable<Reserva>> ListarTodosAsync();
        Task<Reserva?> BuscarPorIdAsync(int id);
        Task AdicionarAsync(Reserva reserva);
        Task Atualizarasync(Reserva reserva);
        Task DeletarAsync(int id);
    }
}