namespace REEP.Domain.Models.MaintenanceModels.MaintenanceTypeModels
{
    public class MaintenanceType
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;
        public IList<Maintenance> Maintenances { get; set; } = [];
    }
}
