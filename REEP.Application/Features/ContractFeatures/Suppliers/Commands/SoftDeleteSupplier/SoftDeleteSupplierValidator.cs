using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.Suppliers.Commands.SoftDeleteSupplier
{
    public class SoftDeleteSupplierValidator
        : AbstractValidator<SoftDeleteSupplierCommand>
    {
        public SoftDeleteSupplierValidator()
        {
            RuleFor(command => command.Id)
                .NotEqual(Guid.Empty);
            RuleFor(command => command.IsDeleted)
                .NotNull();
        }
    }
}
