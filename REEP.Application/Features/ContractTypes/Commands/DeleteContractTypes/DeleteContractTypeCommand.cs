using MediatR;

namespace REEP.Application.Features.ContractTypes.Commands.DeleteContractTypes
{
    public class DeleteContractTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
