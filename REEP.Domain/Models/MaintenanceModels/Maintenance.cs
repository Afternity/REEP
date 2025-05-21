using REEP.Domain.Models.MaintenanceModels.MaintenanceHistoryModels;
using REEP.Domain.Models.MaintenanceModels.MaintenanceTypeModels;

namespace REEP.Domain.Models.MaintenanceModels
{
    public class Maintenance
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = false;
        public string TotalDescription { get; set; } = string.Empty;
        public DateTime? DateOfStart { get; set; }
        public DateTime? PossibleRepairTime { get; set; }
        public DateTime? DateOfEnd { get; set; }
        public Guid MaintenanceTypeId { get; set; }
        public MaintenanceType MaintenanceType { get; set; } = null!;
        public IList<MaintenаnceParametersHistory> HistoryRecords { get; set; } = [];
        public IList<MaintenanceRequest> MaintenanceRequests { get; set; } = [];
    }
}
