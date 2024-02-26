using FluentValidation;
using AdminProSolutions.Domain.Dtos.Authentication;

namespace AdminProSolutions.API.Validations.Authentication
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator() 
        {
            RuleFor(v => v)
                .NotEmpty()
                .NotNull();
        }
    }
}
