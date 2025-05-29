using FluentValidation;

namespace REEP.Application.Features.ContractTypes.Commands.DeleteContractTypes
{
    public class DeleteContractTypeValidation : AbstractValidator<DeleteContractTypeCommand>
    {
        public DeleteContractTypeValidation()
        {
            RuleFor(deleteContractTypeCommand => deleteContractTypeCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
