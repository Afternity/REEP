using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.Suppliers.Commands.HardDeleteSupplier
{
    public class HardDeleteSupplierValidator
        : AbstractValidator<HardDeleteSupplierCommand>
    {
        public HardDeleteSupplierValidator()
        {
            RuleFor(command => command.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
