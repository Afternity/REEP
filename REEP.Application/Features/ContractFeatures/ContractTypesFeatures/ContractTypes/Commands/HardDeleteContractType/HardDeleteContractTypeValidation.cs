using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.ContractTypes.Commands.HardDeleteContractType
{
    public class HardDeleteContractTypeValidation : AbstractValidator<HardDeleteContractTypeCommand>
    {
        public HardDeleteContractTypeValidation()
        {
            RuleFor(deleteContractTypeCommand => deleteContractTypeCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
