namespace REEP.Domain.Models.MaintenanceModels.MaintenanceHistoryModels
{
    public class MaintenenceParametersHistory
    {
        public Guid Id { get; set; }
        public DateTime ChangeDate { get; set; } = DateTime.UtcNow;
        public string ChangeReason { get; set; } = "Update";
        public string Comment { get; set; } = string.Empty;

        public bool MaintenanceIsActive { get; set; } = false;
        public string MaintenanceTatalDescription { get; set; } = string.Empty;
        public string MaintenanceDateOfStart { get; set; } = string.Empty;
        public string MaintenancePossibleRepairTime { get; set; } = string.Empty;
        public string MaintenanceDateOfEnd { get; set; } = string.Empty;

        public string MaintenenceType {  get; set; } = string.Empty;

        public string MaintenanceRequestDescription{  get; set; } = string.Empty;
        public string MaintenanceRequestDateOfReceipt {  get; set; } = string.Empty;
        public string MaintenanceRequestDateOfRegstration { get; set; } = string.Empty;

        public Guid MaintenanceId { get; set; }
    }
}
