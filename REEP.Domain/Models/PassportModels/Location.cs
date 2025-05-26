using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.PassportModels
{
    public class Location : IAuditable, ISoftDeletable
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt{ get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public ICollection<EquipmentPassport> EquipmentPassports { get; set; } = [];
    }
}
