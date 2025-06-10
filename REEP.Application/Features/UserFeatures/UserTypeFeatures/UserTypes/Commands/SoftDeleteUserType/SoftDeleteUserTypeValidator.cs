using FluentValidation;

namespace REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Commands.SoftDeleteUserType
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
