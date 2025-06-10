using MediatR;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypeFeatures.WarrantyTypes.Commands.HardDeleteWarrantyType
{
    public class HardDeleteEquipmentTypeCommand : IRequest<Unit>
    {
        public Guid Id {  get; set; }
    }
}
