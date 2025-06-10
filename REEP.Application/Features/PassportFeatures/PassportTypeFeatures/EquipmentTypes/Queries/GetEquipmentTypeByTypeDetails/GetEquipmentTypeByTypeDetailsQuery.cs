using MediatR;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypesFeatures.EquipmentTypes.Queries.GetEquipmentTypeByTypeDetails
{
    public class GetStatusTypeByTypeDetailsQuery : IRequest<StatusTypeByTypeDetailsVm>
    {
        public string Type { get; set; } = null!;
    }
}
