using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Hoteis.API.DTO
{
    public class QuartoDTO
    {
        [Required]
        public string? Numero_quarto { get; set; }
        [Required]
        public string? categoria { get; set; }
        [Required]
        public int? Capacidade { get; set; }
        [Precision(10, 2)]
        [Required]
        public decimal? Preco_quarto { get; set; }
        public string? Descricao { get; set; } = string.Empty;

    }
}