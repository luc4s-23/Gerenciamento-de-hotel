using Hoteis.API.Model;
using Hoteis.API.DTO;

namespace Hoteis.API.Service
{
    public interface IReservaService
    {
        Task<IEnumerable<Reserva>> GetAllAsync();
        Task<Reserva> GetByIdAsync(int id);
        Task<Reserva> CreateAsync(ReservaDTO dto);
        Task<Reserva> UpdateAsync(int id, ReservaDTO dto);
        Task DeleteAsync(int id);
    }
}