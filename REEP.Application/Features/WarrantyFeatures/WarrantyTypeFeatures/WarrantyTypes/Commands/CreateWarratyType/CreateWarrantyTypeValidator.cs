using FluentValidation;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypeFeatures.WarrantyTypes.Commands.CreateWarrantyType
{
    public class CreateEquipmentTypeValidator 
        : AbstractValidator<CreateEquipmentTypeCommand>
    {
        public CreateEquipmentTypeValidator()
        {
            RuleFor(command => command.Type)
                .NotEmpty().MaximumLength(50);
            RuleFor(command => command.IsDeleted)
                .NotNull();
        }
    }
}
