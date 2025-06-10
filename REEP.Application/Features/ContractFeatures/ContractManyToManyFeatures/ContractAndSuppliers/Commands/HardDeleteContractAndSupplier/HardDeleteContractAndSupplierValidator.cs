using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Commands.HardDeleteContractAndSupplier
{
    public class HardDeleteContractAndSupplierValidator
        : AbstractValidator<HardDeleteContractAndSupplierCommand>
    {
        public HardDeleteContractAndSupplierValidator()
        {
            RuleFor(command => command.ContractId)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.SupplierId)
                .NotEqual(Guid.Empty);
        }
    }
}
