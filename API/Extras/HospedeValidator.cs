using FluentValidation;
using FluentValidation.Validators;
using Hoteis.API.Model;

namespace Hoteis.API.Extras
{
    public class HospedeValidator : AbstractValidator<Hospede>
    {
        public HospedeValidator()
        {
            RuleFor(h => h.Nome_hospede)
                .NotEmpty().WithMessage("O nome é obrigatório");

            RuleFor(h => h.CPF_hospede)
                .Length(11).WithMessage("CPF inválido. Deve conter 11 dígitos");
        }
    }
}