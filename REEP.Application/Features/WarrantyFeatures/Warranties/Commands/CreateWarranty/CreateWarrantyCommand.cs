using MediatR;

namespace REEP.Application.Features.WarrantyFeatures.Warranties.Commands.CreateWarranty
{
    public class CreateWarrantyCommand
        : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Guid ContractId { get; set; }
        public Guid WarrantyTypeId { get; set; }
    }
}
