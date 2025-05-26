using REEP.Domain.Models.MaintenanceModels.MaintenanceTypeModels;
using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.MaintenanceModels
{
    public class Maintenance : IAuditable, ISoftDeletable
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = false;
        public string TotalDescription { get; set; } = string.Empty;
        public DateTime StartedAt { get; set; }
        public TimeSpan PossibleRepairTime { get; set; }
        public DateTime EndedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public Guid MaintenanceTypeId { get; set; }
        public MaintenanceType MaintenanceType { get; set; } = null!;
        public ICollection<MaintenanceRequest> MaintenanceRequests { get; set; } = [];
    }
}
