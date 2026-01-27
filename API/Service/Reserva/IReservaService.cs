using Hoteis.API.Model;
using Hoteis.API.DTO;

namespace Hoteis.API.Service
{
    public interface IReservaService
    {
        Task<List<ReservaReadDTO>> BuscarTodosAsync();
        Task<ReservaReadDTO> BuscarPorIdAsync(int id);
        Task<Reserva> ReservarQuartoAsync(ReservaDTO dto, int Quarto_ID_FK);
        Task<Reserva> AtualizarAsync(int id, ReservaDTO dto);
        Task DeletePorIdAsync(int id);
    }
}