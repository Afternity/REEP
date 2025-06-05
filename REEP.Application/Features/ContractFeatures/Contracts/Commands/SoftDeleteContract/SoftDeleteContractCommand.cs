using MediatR;

namespace REEP.Application.Features.ContractFeatures.Contracts.Commands.SoftDeleteContract
{
    public class SoftDeleteContractCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = true;
    }
}
