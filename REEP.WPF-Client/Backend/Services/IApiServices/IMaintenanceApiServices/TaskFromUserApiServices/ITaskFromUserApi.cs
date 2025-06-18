using Refit;
using REEP.WPF_Client.Backend.Models.MaintenanceModels.TaskFromUserModels;

namespace REEP.WPF_Client.Backend.Services.IApiServices.IMaintenanceApiServices.TaskFromUserApiServices
{
    public interface ITaskFromUserApi
    {
        [Post("/api/v1.0/maintenanceRequest")]
        Task CreateMaintenanceRequset([Body] CreateMaintenanceRequestDto request);
    }
}
