
using System.ComponentModel.DataAnnotations;

namespace Hoteis.API.Model
{
    public class Categoria
    {
        [Key]
        public int Id_Categoria { get; set; }

        public string? Nome_Categoria { get; set; }
    }
}