using REEP.Domain.Models.PassportModels.PassportHistory;
using REEP.Domain.Models.UserModels;
using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.PassportModels
{
    public class EquipmentPassport : IAuditable
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public Guid UserUsedId { get; set; }
        public User UserUsed { get; set; } = null!;
        public Guid UserGrantAccessId { get; set; }
        public User UserGrantAccess { get; set; } = null!;
        public Guid EquipmentId { get; set; }
        public Equipment Equipment { get; set; } = null!;
        public Guid LocationId { get; set; }
        public Location Location { get; set; } = null!;
        public Guid StatusId { get; set; }
        public Status Status { get; set; } = null!;
        public IList<EquipmentParametersHistory> HistoryRecords { get; set; } = null!;
    }
}
