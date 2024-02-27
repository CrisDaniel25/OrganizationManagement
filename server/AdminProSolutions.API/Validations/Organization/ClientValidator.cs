using AdminProSolutions.Domain.Dtos.Organization;
using FluentValidation;

namespace AdminProSolutions.API.Validations.Organization
{
    public class ClientValidator : AbstractValidator<ClientDto>
    {
        public ClientValidator()
        {
            RuleFor(v => v)
                .NotEmpty()
                .NotNull();

            RuleFor(v => v.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(v => v.Email)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50)
                .EmailAddress();

            RuleFor(v => v.Industry)
                .NotEmpty()
                .NotNull()
                .MaximumLength(150);

            RuleFor(v => v.Headquarters)
                .NotEmpty()
                .NotNull()
                .MaximumLength(200);

            RuleFor(v => v.Phone)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);

            RuleFor(v => v.Website)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(v => v.Founded)
                .NotEmpty()
                .NotNull();
        }
    }
}
