using FluentValidation;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypeFeatures.EquipmentTypes.Commands.CreateEquipmentType
{
    public class CreateStatusTypeValidator 
        : AbstractValidator<CreateStatusTypeCommand>
    {
        public CreateStatusTypeValidator()
        {
            RuleFor(command => command.Type)
                .NotEmpty().MaximumLength(50);
            RuleFor(command => command.IsDeleted)
                .NotNull();
        }
    }
}
