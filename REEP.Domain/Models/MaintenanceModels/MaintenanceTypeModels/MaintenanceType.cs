using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.MaintenanceModels.MaintenanceTypeModels
{
    public class MaintenanceType : IAuditable, ISoftDeletable
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public ICollection<Maintenance> Maintenances { get; set; } = [];
    }
}
