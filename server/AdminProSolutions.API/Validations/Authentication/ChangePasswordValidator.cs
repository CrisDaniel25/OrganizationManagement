using AdminProSolutions.Domain.Dtos.Authentication;
using AdminProSolutions.Domain.Enums;
using FluentValidation;

namespace AdminProSolutions.API.Validations.Authentication
{
    public class ChangePasswordValidator : AbstractValidator<UserDto>
    {
        public ChangePasswordValidator()
        {
            RuleFor(v => v)
                .NotEmpty()
                .NotNull();

            RuleFor(v => v.Password)
                .NotNull();

            RuleFor(v => v.NewPassword)    
                .NotNull();

            //RuleFor(v => v.TypeAutentication)
            //    .Equal(TypeAuthentication.EX);
        }
    }
}
