using REEP.Domain.Models.PassportModels.PassportActions;

namespace REEP.Domain.Models.PassportModels.PassportHistory
{
    public class EquipmentPassportHistory
    {
        public Guid Id {  get; set; }
        public DateTime DateOfReceipt { get; set; } = DateTime.UtcNow;

        public Guid EquipmentPassportActionId { get; set; }
        public EquipmentPassportAction EquipmentPassportAction { get; set; } = null!;
        public Guid EquipmentPassportId { get; set; }
        public EquipmentPassport EquipmentPassport { get; set; } = null!;

    }
}
