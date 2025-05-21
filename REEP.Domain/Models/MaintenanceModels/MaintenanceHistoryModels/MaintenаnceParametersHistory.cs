namespace REEP.Domain.Models.MaintenanceModels.MaintenanceHistoryModels
{
    public class MaintenаnceParametersHistory
    {
        public Guid Id { get; set; }
        public DateTime ChangeDate { get; set; } = DateTime.UtcNow;
        public string ChangeReason { get; set; } = "Update";
        public string Comment { get; set; } = string.Empty;

        public bool MaintenanceIsActive { get; set; } = false;
        public string MaintenanceTatalDescription { get; set; } = string.Empty;
        public DateTime? MaintenanceDateOfStart { get; set; } 
        public TimeSpan? MaintenancePossibleRepairTime { get; set; } 
        public DateTime? MaintenanceDateOfEnd { get; set; } 

        public string MaintenenceType {  get; set; } = string.Empty;

        public Guid ModifiedByUserId { get; set; }
        public string ModifiedByUserName { get; set; } = string.Empty;
        public Guid MaintenanceId { get; set; }
    }
}
