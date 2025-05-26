using REEP.Domain.Models.PassportModels.PassportTypeModels;
using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.PassportModels
{
    public class Status : IAuditable, ISoftDeletable
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public Guid StatusTypeId { get; set; }
        public StatusType StatusType { get; set; } = null!;
        public ICollection<EquipmentPassport> EquipmentPassports { get; set; } = [];
    }
}
