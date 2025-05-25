using REEP.Domain.Models.PassportModels.PassportHistory;
using REEP.Domain.Models.UserModels;
using REEP.Domain.InterfaceModels;
using REEP.Domain.Models.WarrantyModels;

namespace REEP.Domain.Models.PassportModels
{
    public class EquipmentPassport : IAuditable
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public Guid? UserUsedId { get; set; }
        public User? UserUsed { get; set; } 
        public Guid UserGrantAccessId { get; set; }
        public User UserGrantAccess { get; set; } = null!;
        public Guid WarrantyId { get; set; }
        public Warranty Warranty { get; set; } = null!;
        public Guid EquipmentId { get; set; }
        public Equipment Equipment { get; set; } = null!;
        public Guid LocationId { get; set; }
        public Location Location { get; set; } = null!;
        public Guid StatusId { get; set; }
        public Status Status { get; set; } = null!;
        public ICollection<EquipmentParametersHistory> HistoryRecords { get; set; } = null!;
    }
}
