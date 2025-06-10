using FluentValidation;

namespace REEP.Application.Features.StatusFeatures.StatusTypeFeatures.StatusTypes.Commands.SoftDeleteStatusType
{
    public class SoftDeleteUserTypeValidator
        : AbstractValidator<SoftDeleteUserTypeCommand>
    {
        public SoftDeleteUserTypeValidator()
        {
            RuleFor(command => command.Id)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.IsDeleted)
                .NotNull();
        }
    }
}
