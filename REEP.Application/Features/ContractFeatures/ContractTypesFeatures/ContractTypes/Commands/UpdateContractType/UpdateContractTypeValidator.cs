using FluentValidation;

namespace REEP.Application.Features.ContractFeatures.ContractTypesFeatures.ContractTypes.Commands.UpdateContractType
{
    public class UpdateContractTypeValidator 
        : AbstractValidator<UpdateContractTypeCommand>
    {
        public UpdateContractTypeValidator()
        {
            RuleFor(updateContractTypeCommand => updateContractTypeCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateContractTypeCommand => updateContractTypeCommand.Type).NotEmpty().MaximumLength(50);
        }
    }
}
