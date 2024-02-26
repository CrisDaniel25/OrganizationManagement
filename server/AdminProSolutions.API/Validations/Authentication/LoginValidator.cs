using FluentValidation;
using AdminProSolutions.Domain.Dtos.Authentication;

namespace AdminProSolutions.API.Validations.Authentication
{
    public class LoginValidator : AbstractValidator<LoginRequestDto>
    {
        public LoginValidator()
        {
            RuleFor(v => v.UserName)
                .NotEmpty()
                .NotNull();

            RuleFor(v => v.Password)
                .NotEmpty()
                .NotNull();
        }
    }
}
