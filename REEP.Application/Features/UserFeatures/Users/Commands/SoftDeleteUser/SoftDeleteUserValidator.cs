using FluentValidation;

namespace REEP.Application.Features.UserFeatures.Users.Commands.SoftDeleteUser
{
    public class SoftDeleteUserValidator
     : AbstractValidator<SoftDeleteUserCommand>
    {
        public SoftDeleteUserValidator()
        {
            RuleFor(command => command.Id)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.IsDeleted)
                .NotNull();
        }
    }
}
