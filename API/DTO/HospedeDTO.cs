using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hoteis.API.Model
{
    public class HospedeDTO
    {
        public string Nome_hospede { get; set; } = string.Empty;
        public string CPF_hospede { get; set; } = string.Empty;
        public string Email_hospede { get; set; } = string.Empty;
        public string Telefone_hospede { get; set; } = string.Empty;
        public Boolean Menor_idade { get; set; }
    }
}