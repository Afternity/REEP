using REEP.Domain.Models.UserModels;
using REEP.Domain.InterfaceModels;
using REEP.Domain.Models.WarrantyModels;

namespace REEP.Domain.Models.PassportModels
{
    public class EquipmentPassport : IAuditable, ISoftDeletable
    {
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public Guid? UserUsedId { get; set; }
        public User? UserUsed { get; set; } 
        public Guid UserGrantAccessId { get; set; }
        public User UserGrantAccess { get; set; } = null!;
        public Guid EquipmentId { get; set; }
        public Equipment Equipment { get; set; } = null!;
        public Guid LocationId { get; set; }
        public Location Location { get; set; } = null!;
        public Guid StatusId { get; set; }
        public Status Status { get; set; } = null!;
    }
}
