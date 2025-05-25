using REEP.Domain.Models.UserModels;
using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.MaintenanceModels
{
    public class MaintenanceRequest : IAuditable, ISoftDeletable
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = false;
        public string Description { get; set; } = string.Empty;
        public DateTime DateOfReceipt { get; set; } = DateTime.UtcNow;
        public DateTime DateOfRegistration {  get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public Guid MaintenanceId { get; set; }
        public Maintenance? Maintenance { get; set; } 
        public Guid CreateByUserId { get; set; }
        public User CreateByUser { get; set; } = null!;
        public Guid? ApprovedByUserId { get; set; }
        public User? ApprovedByUser { get; set; } 
    }
}
