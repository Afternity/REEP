using MediatR;

namespace REEP.Application.Features.EquipmentFeatures.EquipmentTypeFeatures.EquipmentTypes.Commands.CreateEquipmentType
{
    public class CreateStatusTypeCommand : IRequest<Guid>
    {
        public string Type { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;
    }
}
