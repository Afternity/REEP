using REEP.WPF_Client.Backend.Models.MaintenanceModels.TaskFromUserModels;

namespace REEP.WPF_Client.Backend.Services.IApiServices.IMaintenanceApiServices.TaskFromUserApiServices
{
    public interface ITaskFromUserService
    {
        Task<bool> CreateMaintenanceRequset(CreateMaintenanceRequestDto request);
    }
}
