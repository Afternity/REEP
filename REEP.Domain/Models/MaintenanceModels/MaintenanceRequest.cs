using REEP.Domain.Models.UserModels;

namespace REEP.Domain.Models.MaintenanceModels
{
    public class MaintenanceRequest
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = false;
        public string Description { get; set; } = string.Empty;
        public DateTime DateOfReceipt { get; set; } = DateTime.UtcNow;
        public DateTime DateOfRegistration {  get; set; }

        public Guid MaintenanceId { get; set; }
        public Maintenance? Maintenance { get; set; } 
        public Guid CreateByUserId { get; set; }
        public User CreateBy { get; set; } = null!;
        public Guid ApprovedByUserId { get; set; }
        public User? ApprovedBy { get; set; } 
    }
}
