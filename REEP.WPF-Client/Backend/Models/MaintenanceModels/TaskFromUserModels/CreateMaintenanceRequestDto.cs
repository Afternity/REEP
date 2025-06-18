namespace REEP.WPF_Client.Backend.Models.MaintenanceModels.TaskFromUserModels
{
    public class CreateMaintenanceRequestDto
    {
        public string Description { get; set; } = null!;
        public Guid CreateByUserId { get; set; }
    }
}
