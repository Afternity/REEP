using FluentValidation;

namespace REEP.Application.Features.UserFeatures.Users.Commands.HardDeleteUser
{
    public class HardDeleteUserValidator
        : AbstractValidator<HardDeleteUserCommand>
    {
        public HardDeleteUserValidator()
        {
            RuleFor(command => command.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
