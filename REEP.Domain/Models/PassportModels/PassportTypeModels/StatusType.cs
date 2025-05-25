using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.PassportModels.PassportTypeModels
{
    public class StatusType : IAuditable, ISoftDeletable
    {
        public Guid Id { get; set; }
        public string Type {  get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public ICollection<Status> Statuses { get; set; } = [];
    }
}
