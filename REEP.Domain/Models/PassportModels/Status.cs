using REEP.Domain.Models.PassportModels.PassportHistoryModels;
using REEP.Domain.Models.PassportModels.PassportTypeModels;

namespace REEP.Domain.Models.PassportModels
{
    public class Status
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime StartAction { get; set; }
        public DateTime EndAction { get; set; }
        
        public Guid StatusId { get; set; }
        public StatusType StatusType { get; set; } = null!;
        public IList<EquipmentPassport> EquipmentPassports { get; set; } = [];
        public IList<StatusHistory> StatusHistories { get; set; } = [];

    }
}
