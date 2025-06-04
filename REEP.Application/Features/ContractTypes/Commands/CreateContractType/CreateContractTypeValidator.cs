using FluentValidation;

namespace REEP.Application.Features.ContractTypes.Commands.CreateContractType
{
    public class CreateContractTypeValidator 
        : AbstractValidator<CreateContractTypeCommand>
    {
        public CreateContractTypeValidator() 
        {
            RuleFor(createContractTypeCommand =>
                createContractTypeCommand.Type).NotEmpty().MaximumLength(50);
            RuleFor(createContractTypeCommand =>
                createContractTypeCommand.IsDeleted).NotNull();
        }
    }
}
