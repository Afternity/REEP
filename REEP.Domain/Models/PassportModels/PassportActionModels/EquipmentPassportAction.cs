using REEP.Domain.Models.PassportModels.PassportHistory;

namespace REEP.Domain.Models.PassportModels.PassportActions
{
    public class EquipmentPassportAction
    {
        public Guid Id { get; set; }
        public string Action {  get; set; } = string.Empty;
        public IList<EquipmentPassportHistory> EquipmentPassportHistories { get; set; } = [];
    }
}
