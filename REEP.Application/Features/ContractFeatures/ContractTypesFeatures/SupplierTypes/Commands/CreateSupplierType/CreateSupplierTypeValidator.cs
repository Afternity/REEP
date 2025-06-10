using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Commands.CreateSupplierType
{
    public class CreateWarrantyTypeValidator 
        : AbstractValidator<CreateWarrantyTypeCommand>
    {
        public CreateWarrantyTypeValidator()
        {
            RuleFor(createSupplierTypeCommand => createSupplierTypeCommand.Type)
                .NotEmpty().MaximumLength(50);
            RuleFor(createSupplierTypeCommand => createSupplierTypeCommand.IsDeleted)
                .NotNull();
        }
    }
}
