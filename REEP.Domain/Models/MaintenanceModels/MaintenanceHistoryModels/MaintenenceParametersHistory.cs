namespace REEP.Domain.Models.MaintenanceModels.MaintenanceHistoryModels
{
    public class MaintenenceParametersHistory
    {
        public Guid Id { get; set; }
        public DateTime ChangeDate { get; set; } = DateTime.UtcNow;
        public string ChangeReason { get; set; } = "Update";
        public string Comment { get; set; } = string.Empty;
    }
}
