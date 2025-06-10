

using MediatR;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypesFeatures.EquipmentTypes.Queries.GetEquipmentTypeDetails
{
    public class GetStatusTypeDetailsQuery : IRequest<StatusTypeDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
