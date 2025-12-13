using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Hoteis.API.Model
{
    public class Quarto
    {
        [Key]
        public int Id_quarto { get; set; }
        [Required]
        public int Numero_quarto { get; set; }
        [Required]
        public int Categoria_ID_FK { get; set; }
        [Required]
        public int Capacidade { get; set; }
        [Precision(10, 2)]
        [Required]
        public decimal Preco_quarto { get; set; }
        public string? Status { get; set; }
        public string? Descrição { get; set; } 
    }
}