using MediatR;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypeFeatures.WarrantyTypes.Commands.SoftDeleteWarrantyType
{
    public class SoftDeleteEquipmentTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = true;
    }
}
