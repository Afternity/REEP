using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Commands.UpdateContractAndSupplier
{
    public class UpdateContractAndSupplierValidator
        : AbstractValidator<UpdateContractAndSupplierCommand>
    {
        public UpdateContractAndSupplierValidator()
        {
            RuleFor(command => command.ContractId)
             .NotEqual(Guid.Empty);
            RuleFor(command => command.SupplierId)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.IsActive)
                .NotNull();
        }
    }
}
