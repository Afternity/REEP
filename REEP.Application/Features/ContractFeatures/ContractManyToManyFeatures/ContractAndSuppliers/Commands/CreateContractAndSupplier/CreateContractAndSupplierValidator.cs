using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.ContractManyToManyFeatures.ContractAndSuppliers.Commands.CreateContractAndSupplier
{
    public class CreateContractAndSupplierValidator
        : AbstractValidator<CreateContractAndSupplierCommand>
    {
        public CreateContractAndSupplierValidator()
        {
            RuleFor(command => command.ContractId)
               .NotEqual(Guid.Empty);
            RuleFor(command => command.SupplierId)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.IsActive)
                .NotNull();
            RuleFor(command => command.IsDeleted)
                .NotNull();
        }
    }
}
