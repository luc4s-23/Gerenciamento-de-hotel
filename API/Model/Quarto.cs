using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Hoteis.API.Model
{
    public class Quarto
    {
        [Key]
        public int Id_quarto { get; set; }
        [Required]
        public string? Numero_quarto { get; set; }
        [Required]
        public TipoQuarto tipo { get; set; }
        [Required]
        public int Capacidade { get; set; }
        [Precision(10, 2)]
        [Required]
        [Range(0.00, double.MaxValue)]
        public decimal Preco_diaria { get; set; }
        public StatusQuarto Status { get; private set; } = StatusQuarto.Disponível;
        public string? Descricao { get; set; }


        public void Ocupar()
        {
            if (Status == StatusQuarto.Ocupado)
                throw new InvalidOperationException("Quarto já está ocupado.");

            Status = StatusQuarto.Ocupado;
        }

    }
}

public enum StatusQuarto
{
    Disponível,
    Ocupado
}

public enum TipoQuarto
{
    Standard,
    Luxo,
    Suite,
    Presidential
}