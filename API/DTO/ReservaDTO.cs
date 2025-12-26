
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Hoteis.API.DTO
{
    public class ReservaDTO
    {
        public int Quarto_ID_FK { get; set; }
        [Required]
        public string? Nome_hospede { get; set; }
        [Required]
        public string? Contato_hospede { get; set; }
        [Required]
        public string? Documento_hospede { get; set; }
        [Required]
        public DateTime? Data_entrada { get; set; }
        public DateTime? Data_saida { get; set; }
        [Precision(10, 2)]
        public decimal? Preco_total { get; set; }
        public int? Quantidade_hospedes { get; set; }
    }
}