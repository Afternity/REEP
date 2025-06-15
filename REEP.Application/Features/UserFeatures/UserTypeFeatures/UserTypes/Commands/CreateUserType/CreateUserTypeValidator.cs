using FluentValidation;

namespace REEP.Application.Features.UserFeatures.UserTypeFeatures.UserTypes.Commands.CreateUserType
{
    public class CreateUserTypeValidator
        : AbstractValidator<CreateUserTypeCommand>
    {
        public CreateUserTypeValidator()
        {
            RuleFor(command => command.Type)
                .NotEmpty().MaximumLength(50);
            RuleFor(command => command.IsDeleted)
                .NotNull();
        }
    }
}
