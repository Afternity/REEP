using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Commands.SoftDeleteContractAndSupplier
{
    public class SoftDeleteContractAndSupplierValidator
        : AbstractValidator<SoftDeleteContractAndSupplierCommand>
    {
        public SoftDeleteContractAndSupplierValidator()
        {
            RuleFor(command => command.ContractId)
              .NotEqual(Guid.Empty);
            RuleFor(command => command.SupplierId)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.IsDeleted)
                .NotNull();
        }
    }
}
