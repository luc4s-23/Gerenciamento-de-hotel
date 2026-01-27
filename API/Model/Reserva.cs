using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace Hoteis.API.Model
{
    public class Reserva
    {
        [Key]
        public int Id_reserva { get; set; }
        [Required]
        public int Quarto_ID_FK { get; set; }
        public Quarto? Quarto { get; set; }
        [Required]
        public string Nome_hospede { get; set; }
        [Required]
        public string Contato_hospede { get; set; }
        [Required]
        public string Documento_hospede { get; set; }
        public DateTime DataReserva { get; set; }
        [Required]
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }
        public StatusReserva Status { get; set; }
        [Precision(10, 2)]
        public decimal Preco_total { get; set; }
        [Required]
        [Range(1, 365)]
        public int QuantidadeDiarias { get; set; }
        public int Quantidade_hospedes { get; set; }
        public decimal ValorTotal { get; set; }

        public void CalcularValorTotal()
        {
            if (Quarto != null)
            {

            }
        }
        public enum StatusReserva
        {
            Confirmada,
            CheckInRealizado,
            Finalizada,
            Cancelada
        }
    }
}


