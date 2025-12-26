// using System.ComponentModel.DataAnnotations;
// using Microsoft.EntityFrameworkCore;

// namespace Hoteis.API.Model
// {
//     [Index(nameof(CPF_hospede), IsUnique = true)]
//     public class Hospede
//     {
//         [Key]
//         public int Id_hospede { get; set; }
//         [Required]
//         public string Nome_hospede { get; set; } = string.Empty;

//         [Required]
//         [StringLength(11)]
//         public string CPF_hospede { get; set; } = string.Empty;
//         public string Email_hospede { get; set; } = string.Empty;
        
//         [Required]
//         public string Telefone_hospede { get; set; } = string.Empty;
//         public Boolean Menor_idade { get; set; }

//         public ICollection<Reserva> reservas { get; set; }
//     }
// }

//Classe inoperante