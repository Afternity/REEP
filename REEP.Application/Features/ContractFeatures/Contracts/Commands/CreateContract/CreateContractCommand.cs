using MediatR;

namespace REEP.Application.Features.ContractFeatures.Contracts.Commands.CreateContract
{
    public class CreateContractCommand : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Type { get; set; } = null!;
    }
}
