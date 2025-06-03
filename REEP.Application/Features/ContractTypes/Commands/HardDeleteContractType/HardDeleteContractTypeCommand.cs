using MediatR;

namespace REEP.Application.Features.ContractTypes.Commands.HardDeleteContractType
{
    public class HardDeleteContractTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
