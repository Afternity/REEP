using MediatR;

namespace REEP.Application.Features.ContractFeatures.Contracts.Commands.HardDeleteContract
{
    public class HardDeleteContractCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
