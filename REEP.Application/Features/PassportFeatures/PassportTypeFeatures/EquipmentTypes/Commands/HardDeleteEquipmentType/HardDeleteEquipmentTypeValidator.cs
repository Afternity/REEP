using FluentValidation;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypeFeatures.EquipmentTypes.Commands.HardDeleteEquipmentType
{
    public class HardDeleteStatusTypeValidator
        : AbstractValidator<HardDeleteStatusTypeCommand>
    {
        public HardDeleteStatusTypeValidator()
        {
            RuleFor(command => command.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
