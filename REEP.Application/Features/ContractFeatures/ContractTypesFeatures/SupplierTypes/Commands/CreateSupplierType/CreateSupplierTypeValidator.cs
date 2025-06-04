using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Commands.CreateSupplierType
{
    public class CreateSupplierTypeValidator 
        : AbstractValidator<CreateSupplierTypeCommand>
    {
        public CreateSupplierTypeValidator()
        {
            RuleFor(createSupplierTypeCommand => createSupplierTypeCommand.Type)
                .NotEmpty().MaximumLength(50);
            RuleFor(createSupplierTypeCommand => createSupplierTypeCommand.IsDeleted)
                .NotNull();
        }
    }
}
