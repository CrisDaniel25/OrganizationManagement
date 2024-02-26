using AdminProSolutions.Domain.Dtos.Authentication;
using FluentValidation;

namespace AdminProSolutions.API.Validations.Authentication
{
    public class RoleValidator : AbstractValidator<GroupsDto>
    {
        public RoleValidator()
        {
            RuleFor(v => v)
                .NotEmpty()
                .NotNull();
        }
    }
}
