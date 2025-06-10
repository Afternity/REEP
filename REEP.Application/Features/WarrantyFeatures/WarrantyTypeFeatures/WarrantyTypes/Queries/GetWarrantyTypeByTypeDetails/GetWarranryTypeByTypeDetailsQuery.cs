using MediatR;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypesFeatures.WarrantyTypes.Queries.GetWarrantyTypeByTypeDetails
{
    public class GetEquipmentTypeByTypeDetailsQuery : IRequest<EquipmentTypeByTypeDetailsVm>
    {
        public string Type { get; set; } = null!;
    }
}
