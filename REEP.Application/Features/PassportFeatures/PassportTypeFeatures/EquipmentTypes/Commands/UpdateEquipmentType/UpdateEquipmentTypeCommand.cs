using MediatR;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypeFeatures.EquipmentTypes.Commands.UpdateEquipmentType
{
    public class UpdateStatusTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;
    }
}
