using MediatR;

namespace REEP.Application.Features.WarrantyFeatures.Warranties.Commands.CreateWarrantyByType
{
    public class CreateWarrantyByTypeCommand
        : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Guid ContractId { get; set; }
        public string WarrantyType { get; set; } = null!;
    }
}
