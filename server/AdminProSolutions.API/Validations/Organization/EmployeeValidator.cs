using AdminProSolutions.Domain.Dtos.Organization;
using FluentValidation;

namespace AdminProSolutions.API.Validations.Organization
{
    public class EmployeeValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeValidator()
        {
            RuleFor(v => v)
                .NotEmpty()
                .NotNull();

            RuleFor(v => v.IdentityDocument)
                .NotEmpty()
                .NotNull();

            RuleFor(v => v.FirstName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(v => v.MiddleName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(v => v.LastName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(v => v.Email)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100)
                .EmailAddress();

            RuleFor(v => v.Phone)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);

            RuleFor(v => v.Gender)
                .NotEmpty()
                .NotNull()
                .MaximumLength(1);

            RuleFor(v => v.BirthDate)
                .NotEmpty()
                .NotNull();

            RuleFor(v => v.Department)
                .NotEmpty()
                .NotNull()
                .MaximumLength(150);

            RuleFor(v => v.Position)
                .NotEmpty()
                .NotNull()
                .MaximumLength(150);

        }
    }
}
