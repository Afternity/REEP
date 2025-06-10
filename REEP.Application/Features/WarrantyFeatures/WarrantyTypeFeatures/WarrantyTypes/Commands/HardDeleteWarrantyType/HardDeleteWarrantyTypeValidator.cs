using FluentValidation;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypeFeatures.WarrantyTypes.Commands.HardDeleteWarrantyType
{
    public class HardDeleteEquipmentTypeValidator
        : AbstractValidator<HardDeleteEquipmentTypeCommand>
    {
        public HardDeleteEquipmentTypeValidator()
        {
            RuleFor(command => command.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
