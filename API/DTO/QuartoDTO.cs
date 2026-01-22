using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Hoteis.API.DTO
{
    public class QuartoDTO
    {
        [Required]
        public string? Numero_quarto { get; set; }
        [Required]
        public TipoQuarto tipo { get; set; }
        [Required]
        public int? Capacidade { get; set; }
        [Precision(10, 2)]
        [Required]
        [Range(0.00, double.MaxValue)]
        public decimal? Preco_diaria { get; set; }
        public string? Descricao { get; set; } = string.Empty;

    }
    
}