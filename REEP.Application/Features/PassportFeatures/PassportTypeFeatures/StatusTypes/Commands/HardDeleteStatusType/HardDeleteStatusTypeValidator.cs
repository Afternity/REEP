using FluentValidation;

namespace REEP.Application.Features.StatusFeatures.StatusTypeFeatures.StatusTypes.Commands.HardDeleteStatusType
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
