using MediatR;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypeFeatures.EquipmentTypes.Commands.SoftDeleteEquipmentType
{
    public class SoftDeleteStatusTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = true;
    }
}
