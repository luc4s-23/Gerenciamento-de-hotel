using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace Hoteis.API.Model
{
    public class Reserva
    {
        [Key]
        public int Id_reserva { get; set; }
        public DateTime Data_entrada { get; set; }
        public DateTime Data_saida { get; set; }
        public int Quantidade_hospedes { get; set; }
        public Quarto Quarto { get; set; }
        public int Quarto_ID_FK { get; set; }
        public Hospede hospede { get; set; }
        public int Hospede_ID_FK { get; set; }
        [Precision(10, 2)]
        public decimal Preco_total { get; set; }
    }
}