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
        public Guid UserUsedId { get; set; }
        public User User { get; set; } = null!;
        public IList<User> Admins { get; set; } = [];
    }
}
