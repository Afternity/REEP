using REEP.Domain.Models.PassportModels.PassportHistoryModels;

namespace REEP.Domain.Models.PassportModels.PassportActionModels
{
    public class EquipmentAction
    {
        public Guid Id { get; set; }
        public string Action {  get; set; } = string.Empty;
        public IList<EquipmentHistory> EquipmentHistories { get; set; } = [];
    }
}
