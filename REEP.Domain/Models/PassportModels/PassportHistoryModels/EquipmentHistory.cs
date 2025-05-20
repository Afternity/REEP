using REEP.Domain.Models.PassportModels.PassportActionModels;

namespace REEP.Domain.Models.PassportModels.PassportHistoryModels
{
    public class EquipmentHistory
    {
        public Guid Id { get; set; }
        public DateTime DateOfReceipt { get; set; } = DateTime.Now;

        public Guid EquipmentId { get; set; }
        public Equipment Equipment { get; set; } = null!;
        public Guid EquipmentActionId { get; set; }
        public EquipmentAction EquipmentAction { get; set; } = null!;
    }
}
