using FluentValidation;

namespace REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Commands.HardDeleteUserType
{
    public class HardDeleteUserTypeValidator
        : AbstractValidator<HardDeleteUserTypeCommand>
    {
        public HardDeleteUserTypeValidator()
        {
            RuleFor(command => command.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
