using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.Contracts.Commands.HardDeleteContract
{
    public class HardDeleteContractValidator
        : AbstractValidator<HardDeleteContractCommand>
    {
        public HardDeleteContractValidator()
        {
            RuleFor(hardDeleteContractCommmand => hardDeleteContractCommmand.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
