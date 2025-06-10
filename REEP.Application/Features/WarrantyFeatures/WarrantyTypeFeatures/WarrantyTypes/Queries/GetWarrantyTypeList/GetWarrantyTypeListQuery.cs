using MediatR;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypesFeatures.WarrantyTypes.Queries.GetWarrantyTypeList
{
    public class GetEquipmentTypeListQuery : IRequest<EquipmentTypeListVm>
    {
        public bool IsDeleted { get; set; } = false;
    }
}
