using FluentValidation;

namespace REEP.Application.Features.ContractTypes.Commands.SoftDeleteContractType
{
    public class SoftDeleteContractTypeValidation
        : AbstractValidator<SoftDeleteContractTypeCommand>
    {
        public SoftDeleteContractTypeValidation()
        {
            RuleFor(softDeleteContractTypeCommand => softDeleteContractTypeCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
