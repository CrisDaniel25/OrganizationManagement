using FluentValidation;
using AdminProSolutions.Domain.Dtos.Authentication;

namespace AdminProSolutions.API.Validations.Authentication
{
    public class RegisterValidator : AbstractValidator<RegisterRequestDto>
    {
        public RegisterValidator() { }
    }
}
