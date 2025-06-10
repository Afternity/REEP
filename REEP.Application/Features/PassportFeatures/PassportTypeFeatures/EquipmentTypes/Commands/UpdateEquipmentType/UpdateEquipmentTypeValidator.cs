using FluentValidation;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypeFeatures.EquipmentTypes.Commands.UpdateEquipmentType
{
    public class UpdateStatusTypeValidator
        : AbstractValidator<UpdateStatusTypeCommand>
    {
        public UpdateStatusTypeValidator()
        {
            RuleFor(command => command.Id)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.Type)
                .NotEmpty().MaximumLength(50);
        }
    }
}
