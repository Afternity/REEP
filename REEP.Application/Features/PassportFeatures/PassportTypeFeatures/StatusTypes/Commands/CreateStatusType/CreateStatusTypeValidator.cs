using FluentValidation;

namespace REEP.Application.Features.StatusFeatures.StatusTypeFeatures.StatusTypes.Commands.CreateStatusType
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
