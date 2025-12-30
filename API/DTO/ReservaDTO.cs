
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Hoteis.API.DTO
{
    public class ReservaDTO
    {
        [Required]
        public string? Nome_hospede { get; set; }
        [Required]
        public string? Contato_hospede { get; set; }
        [Required]
        public string? Documento_hospede { get; set; }
        public int? Quantidade_hospedes { get; set; }
        [Required]
        public int Quantidade_diarias { get; set; }
    }
}