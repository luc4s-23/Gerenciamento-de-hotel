
using static Hoteis.API.Model.Reserva;

namespace Hoteis.API.DTO
{
    public class ReservaReadDTO
    {
        public int IdReserva { get; set; }
        public string NumeroQuarto { get; set; }
        public TipoQuarto TipoQuarto { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }
        public int QuantidadeDiarias { get; set; }
        public decimal ValorTotal { get; set; }
        public StatusReserva Status { get; set; }
    }
}