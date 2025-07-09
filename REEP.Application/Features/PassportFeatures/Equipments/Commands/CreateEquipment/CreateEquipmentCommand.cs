using MediatR;

namespace REEP.Application.Features.PassportFeatures.Equipments.Commands.CreateEquipment
{
    public class CreateEquipmentCommand
        : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;
        public Guid EquipmentTypeId { get; set; }
        public Guid? TechnicalParameterId { get; set; }
        public Guid? WarrantyId { get; set; }
    }
}
