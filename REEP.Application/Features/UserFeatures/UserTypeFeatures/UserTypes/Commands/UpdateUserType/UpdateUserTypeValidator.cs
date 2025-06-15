using FluentValidation;

namespace REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Commands.UpdateUserType
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
