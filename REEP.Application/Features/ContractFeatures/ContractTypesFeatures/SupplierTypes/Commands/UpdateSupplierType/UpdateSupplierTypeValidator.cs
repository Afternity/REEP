using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Commands.UpdateSupplierType
{
    public class UpdateSupplierTypeValidator
        : AbstractValidator<UpdateSupplierTypeCommand>
    {
        public UpdateSupplierTypeValidator()
        {
            RuleFor(updateSupplierTypeCommand => updateSupplierTypeCommand.Id)
                .NotEqual(Guid.Empty);
            RuleFor(updateSupplierTypeCommand => updateSupplierTypeCommand.Type)
                .NotEmpty().MaximumLength(50);
        }
    }
}
