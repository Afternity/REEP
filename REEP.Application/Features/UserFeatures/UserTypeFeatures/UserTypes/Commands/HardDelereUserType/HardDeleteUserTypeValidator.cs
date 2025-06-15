using FluentValidation;

namespace REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Commands.HardDelereUserType
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
