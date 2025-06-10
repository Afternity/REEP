using MediatR;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypeFeatures.WarrantyTypes.Commands.UpdateWarrantyType
{
    public class UpdateEquipmentTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;
    }
}
