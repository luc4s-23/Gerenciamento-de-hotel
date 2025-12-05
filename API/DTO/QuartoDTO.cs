using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Hoteis.API.DTO
{
    public class QuartoDTO
    {
        [Required]
        public int Numero_quarto { get; set; }
        [Required]
        public string Tipo { get; set; } = string.Empty;
        public int Categoria_ID_FK { get; set; }
        [Required]
        public int Capacidade { get; set; }
        [Precision(10, 2)]
        [Required]
        public decimal Preco_quarto { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Descrição { get; set; } = string.Empty;
    }
}