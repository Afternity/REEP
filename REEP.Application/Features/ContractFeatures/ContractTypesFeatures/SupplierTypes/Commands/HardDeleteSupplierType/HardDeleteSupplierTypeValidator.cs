using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.SupplierTypes.Commands.HardDeleteSupplierType
{
    public class HardDeleteSupplierTypeValidator
        : AbstractValidator<HardDeleteSupplierTypeCommand>
    {
        public HardDeleteSupplierTypeValidator()
        {
            RuleFor(hardDeleteSupplierTypeCommand => hardDeleteSupplierTypeCommand.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
