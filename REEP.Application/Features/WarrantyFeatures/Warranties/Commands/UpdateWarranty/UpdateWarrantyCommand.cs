using MediatR;
using REEP.Domain.Models.WarrantyModels.WarrantyTypeModels;

namespace REEP.Application.Features.WarrantyFeatures.Warranties.Commands.UpdateWarranty
{
    public class UpdateWarrantyCommand
        : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public Guid ContractId { get; set; }
        public Guid WarrantyTypeId { get; set; }
    }
}
