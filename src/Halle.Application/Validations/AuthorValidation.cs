using FluentValidation;
using Halle.App.ViewModels;

namespace Halle.Application.Validations
{
    public class AuthorValidation : AbstractValidator<AuthorViewModel>
    {
        public AuthorValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O campo nome precisa ser preenchido")
                .Length(2, 100).WithMessage("O campo nome precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
