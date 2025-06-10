using FluentValidation;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypeFeatures.WarrantyTypes.Commands.UpdateWarrantyType
{
    public class UpdateEquipmentTypeValidator
        : AbstractValidator<UpdateEquipmentTypeCommand>
    {
        public UpdateEquipmentTypeValidator()
        {
            RuleFor(command => command.Id)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.Type)
                .NotEmpty().MaximumLength(50);
        }
    }
}
