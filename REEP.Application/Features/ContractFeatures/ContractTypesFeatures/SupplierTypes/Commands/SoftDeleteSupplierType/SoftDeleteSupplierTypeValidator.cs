using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Commands.SoftDeleteSupplierType
{
    public class SoftDeleteSupplierTypeValidator
        : AbstractValidator<SoftDeleteSupplierTypeCommand>
    {
        public SoftDeleteSupplierTypeValidator()
        {
            RuleFor(softDeleteSupplierTypeValidator => softDeleteSupplierTypeValidator.Id)
                .NotEqual(Guid.Empty);
            RuleFor(softDeleteSupplierTypeValidator => softDeleteSupplierTypeValidator.IsDeleted)
                .NotNull();
        }
    }
}
