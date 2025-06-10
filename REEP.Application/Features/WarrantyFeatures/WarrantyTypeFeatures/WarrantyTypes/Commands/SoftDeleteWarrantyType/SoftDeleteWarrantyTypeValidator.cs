using FluentValidation;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypeFeatures.WarrantyTypes.Commands.SoftDeleteWarrantyType
{
    public class SoftDeleteEquipmentTypeValidator
        : AbstractValidator<SoftDeleteEquipmentTypeCommand>
    {
        public SoftDeleteEquipmentTypeValidator()
        {
            RuleFor(command => command.Id)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.IsDeleted)
                .NotNull();
        }
    }
}
