

using MediatR;

namespace REEP.Application.Features.WarrantyFeatures.WarrantyTypesFeatures.WarrantyTypes.Queries.GetWarrantyTypeDetails
{
    public class GetEquipmentTypeDetailsQuery : IRequest<EquipmentTypeDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
