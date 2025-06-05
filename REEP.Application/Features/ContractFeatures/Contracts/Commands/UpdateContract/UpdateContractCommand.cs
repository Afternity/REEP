using MediatR;

namespace REEP.Application.Features.ContractFeatures.Contracts.Commands.UpdateContract
{
    public class UpdateContractCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public string Type { get; set; } = null!;
    }
}
