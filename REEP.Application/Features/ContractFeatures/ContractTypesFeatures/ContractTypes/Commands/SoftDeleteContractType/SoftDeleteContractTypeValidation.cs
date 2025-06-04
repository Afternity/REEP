using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.ContractTypes.Commands.SoftDeleteContractType
{
    public class SoftDeleteContractTypeValidation
        : AbstractValidator<SoftDeleteContractTypeCommand>
    {
        public SoftDeleteContractTypeValidation()
        {
            RuleFor(softDeleteContractTypeCommand => softDeleteContractTypeCommand.Id).NotEqual(Guid.Empty);
            RuleFor(softDeleteContractTypeCommand => softDeleteContractTypeCommand.IsDeleted).NotNull();
        }
    }
}
