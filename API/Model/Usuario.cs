using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hoteis.API.Model
{
    public class Usuario
    {
        [Key]
        public int Id_Usuario { get; set; }
        public string? Nome_usuario { get; set; }
        public string? Email_usuario { get; set; }
        public string? Senha_Hash { get; set; }
        public int Tipo_user { get; set; }

    }
}