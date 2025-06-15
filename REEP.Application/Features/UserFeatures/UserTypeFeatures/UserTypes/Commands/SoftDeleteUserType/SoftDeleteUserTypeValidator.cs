using FluentValidation;

namespace REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Commands.SoftDeleteUserType
{
    internal class SoftDeleteUserTypeValidator
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
