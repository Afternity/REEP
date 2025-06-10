using MediatR;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypeFeatures.EquipmentTypes.Commands.HardDeleteEquipmentType
{
    public class HardDeleteStatusTypeCommand : IRequest<Unit>
    {
        public Guid Id {  get; set; }
    }
}
