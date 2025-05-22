using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.MaintenanceModels.MaintenanceTypeModels
{
    public class MaintenanceType : IAuditable
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public ICollection<Maintenance> Maintenances { get; set; } = [];
    }
}
