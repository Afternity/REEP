using FluentValidation;

namespace REEP.Application.Features.ContractTypes.Commands.UpdateContractTypes
{
    public class UpdateContractTypeValidator 
        : AbstractValidator<UpdateContractTypeCommand>
    {
        public UpdateContractTypeValidator()
        {
            RuleFor(updateContractTypeCommand => updateContractTypeCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateContractTypeCommand => updateContractTypeCommand.Type).NotEmpty().MaximumLength(50);
            RuleFor(updateContractTypeCommand => updateContractTypeCommand.CreatedAt).NotEmpty();
            RuleFor(updateContractTypeCommand => updateContractTypeCommand.UpdatedAt).NotEmpty();
        }
    }
}
