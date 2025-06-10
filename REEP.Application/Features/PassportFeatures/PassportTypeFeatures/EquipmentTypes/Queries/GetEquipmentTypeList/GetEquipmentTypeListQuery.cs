using MediatR;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypesFeatures.EquipmentTypes.Queries.GetEquipmentTypeList
{
    public class GetStatusTypeListQuery : IRequest<StatusTypeListVm>
    {
        public bool IsDeleted { get; set; } = false;
    }
}
