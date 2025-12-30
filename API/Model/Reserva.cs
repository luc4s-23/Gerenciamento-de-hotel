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
        [Required]
        public string Nome_hospede { get; set; }
        [Required]
        public string Contato_hospede { get; set; }
        [Required]
        public string Documento_hospede { get; set; }
        [Required]
        public DateTime Data_entrada { get; set; }
        public DateTime? Data_saida { get; set; } = null;
        [Precision(10, 2)]
        public decimal Preco_total { get; set; }
        public int Quantidade_hospedes { get; set; }
        public int Quantidade_diarias { get; set; }
    }
}