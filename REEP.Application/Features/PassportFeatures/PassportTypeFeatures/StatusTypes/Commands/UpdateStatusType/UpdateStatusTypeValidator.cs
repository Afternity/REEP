using FluentValidation;

namespace REEP.Application.Features.StatusFeatures.StatusTypeFeatures.StatusTypes.Commands.UpdateStatusType
{
    public class UpdateUserTypeValidator
        : AbstractValidator<UpdateUserTypeCommand>
    {
        public UpdateUserTypeValidator()
        {
            RuleFor(command => command.Id)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.Type)
                .NotEmpty().MaximumLength(50);
        }
    }
}
